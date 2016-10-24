using System;
using System.Linq;
using TrainerEnglish;
using TrainerEnglish.Users;

namespace TrainerEnglish.Application
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public RegistrationService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public int RegisterUser(string nickname)
        {
            var newUserId = new Func<int>(() =>
            {
                var userProfiles = _userProfileRepository.GetAllUserProfiles();
                return userProfiles.Max(user => user.Id) + 1;
            })();
            var newUserProfile = new UserProfile(newUserId, nickname, new LearnedWord[0]);
            _userProfileRepository.SaveUserProfile(newUserProfile);
            return newUserId;
        }
    }
}
