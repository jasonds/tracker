using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using tracker.application.Contracts;
using tracker.domain.Repositories;
using tracker.domain.Services;
using AppModel = tracker.application.Models;
using DomainModel = tracker.domain.Models;

namespace tracker.application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            if (userRepository == null) throw new ArgumentNullException(nameof(userRepository));
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<DomainModel.User>> GetAllAsync()
        {
            return await this._userRepository.GetAllAsync();
        }

        public async Task AddAsync(AppModel.User user)
        {
            this.AddUser(user);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ICollection<AppModel.User> users)
        {
            await this.UpdateUserAsync(users);
            await this._unitOfWork.SaveChangesAsync();
        }

        private void AddUser(AppModel.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user.FirstName)
                || string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new InvalidDataException("First and Last Name are Required");
            }

            DomainModel.User domainUser = new DomainModel.User(Guid.NewGuid());
            domainUser.FirstName = user.FirstName;
            domainUser.LastName = user.LastName;
            domainUser.Status = user.Status;

            this._userRepository.Add(domainUser);
        }

        private async Task UpdateUserAsync(ICollection<AppModel.User> users)
        {
            if (users == null) throw new ArgumentNullException(nameof(users));

            foreach (AppModel.User user in users)
            {
                var domainUser = await this._userRepository.GetByIdAsync(user.Id);
                domainUser.Status = user.Status;
            }
        }
    }
}
