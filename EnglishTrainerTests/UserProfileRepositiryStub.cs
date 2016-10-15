using Newtonsoft.Json;
using TrainerEnglish;
using TrainerEnglish.Users;

namespace EnglishTrainerTests
{
    class UserProfileRepositiryStub : IUserProfileRepository
    {
        private readonly string _jsonDatabase;

        public UserProfileRepositiryStub(string json)
        {
            _jsonDatabase = json;
        }

        public IUserProfile[] GetAllUserProfiles()
        {
            var userProfiles = JsonConvert.DeserializeObject<UserProfile[]>(_jsonDatabase);
            return userProfiles;
        }

        public IUserProfile GetUserProfile(int userId)
        {
            var userProfiles = GetAllUserProfiles();
            foreach (var userProfile in userProfiles)
            {
                if (userProfile.Id == userId)
                {
                    return userProfile;
                }
            }

            return null;
        }

        public void SaveUserProfile(IUserProfile userProfile)
        {
        }
    }
}
