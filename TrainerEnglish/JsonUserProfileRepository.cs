﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrainerEnglish.Users;

namespace TrainerEnglish
{
    public class JsonUserProfileRepository : IUserProfileRepository
    {
        private readonly string _databaseFilePath;

        public JsonUserProfileRepository(string databaseFilePath)
        {
            _databaseFilePath = databaseFilePath;
        }

        public IUserProfile[] GetAllUserProfiles()
        {
            var serializedUsers = File.ReadAllText(_databaseFilePath);
            var userProfiles = JsonConvert.DeserializeObject<UserProfile[]>(serializedUsers);
            return userProfiles;
        }

        public IUserProfile GetUserProfile(int userId)
        {
            var userProfiles = GetAllUserProfiles();
            return userProfiles.FirstOrDefault(user => user.Id == userId);
        }

        public void SaveUserProfile(IUserProfile userProfile)
        {
            var userProfiles = new List<IUserProfile>(GetAllUserProfiles());
            userProfiles.Add(userProfile);
            var serializedUsers = JsonConvert.SerializeObject(userProfiles.ToArray());
            File.WriteAllText(_databaseFilePath, serializedUsers);
        }
    }
}
