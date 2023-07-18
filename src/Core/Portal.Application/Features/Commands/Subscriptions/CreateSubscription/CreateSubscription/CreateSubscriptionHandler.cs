using AutoMapper;
using MediatR;
using Portal.Application.Repositories;
using Portal.Domain.Entities;
using Portal.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Features.Commands.Subscriptions.CreateSubscription.CreateSubscription
{
    public class CreateSubscriptionHandler : IRequestHandler<CreateSubscriptionRequest, CreateSubscriptionResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateSubscriptionHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        async Task<CreateSubscriptionResponse> IRequestHandler<CreateSubscriptionRequest, CreateSubscriptionResponse>.Handle(CreateSubscriptionRequest request, CancellationToken cancellationToken)
        {
            Category category= await _categoryRepository.GetByIdAysnc(request.CategoryId.ToString());

            Category newCategory = new()
            {
                Id = request.CategoryId,
                Content = category.Content,
                CreatedDate = DateTime.UtcNow,
                Users = new HashSet<CategoryUser>()
                {
                    new(){ UserId = request.UserId}
                }
            };

            _categoryRepository.Update(newCategory);
            await _categoryRepository.SaveAysnc();

            return new()
            {
                Message = "Kayıt başarılı"
            };
        }
    }
}
