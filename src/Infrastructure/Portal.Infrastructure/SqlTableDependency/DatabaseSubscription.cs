using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Application.DTOs;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Users;
using Portal.Infrastructure.Hubs;
using System.Text.Json;
using TableDependency.SqlClient;

namespace Portal.Infrastructure.SqlTableDependency
{
    public interface IDatabaseSubscription
    {
        void Configure(string tableName);
    }
    public class DatabaseSubscription<T> : IDatabaseSubscription where T : class, new()
    {
        SqlTableDependency<T> _tableDependency;
        IConfiguration _configuration;
        IHubContext<MessageHub> _hubContext;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        

        public DatabaseSubscription(IConfiguration configuration, IHubContext<MessageHub> hubContext, IServiceScopeFactory serviceScopeFactory)
        {
            _configuration = configuration;
            _hubContext = hubContext;
            _serviceScopeFactory = serviceScopeFactory;            
        }

        public void Configure(string tableName)
        {
            _tableDependency = new SqlTableDependency<T>(_configuration.GetConnectionString("DefaultConnection"), tableName);
            _tableDependency.OnChanged += async (o, e) =>
            {
                List<Message> datas;
                T dataBack = new T();
                UserManager<User> _userManager;
                Message message = null;
                User user = null;
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                     _userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                    dataBack = e.Entity;

                    message = (Message)Convert.ChangeType(dataBack, typeof(Message));
                     user = await _userManager.FindByIdAsync(message.Id.ToString());
                }               

                MessageUserDTO dto = new()
                {
                    MessageContent = message.MessageContent,
                    MessageId = message.Id,
                    UserId = user.Id,
                    UserName=user.UserName
                };

                string jsonData = JsonSerializer.Serialize(dto);
                await _hubContext.Clients.All.SendAsync("receiveMessage", jsonData);


            };
            _tableDependency.OnError += (o, e) =>
            {

            };
            _tableDependency.Start();
        }

        ~DatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }
}
