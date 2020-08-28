using System.Linq;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.System
{
    /// <summary>
    /// UserProfileFacade
    /// </summary>
    public class UserProfileFacade
    {
        private static readonly IUserProfileDao UserProfileDao = DataAccess.DataAccess.UserProfileDao;

        public List<UserProfileEntity> GetUserProfiles()
        {
            return UserProfileDao.GetUserProfiles();
        }

        public UserProfileEntity GetUserProfile(string userProfileId)
        {
            return UserProfileDao.GetUserProfile(userProfileId);
        }

        public UserProfileEntity GetUserProfileByUserName(string userName)
        {
            return UserProfileDao.GetUserProfileByUserName(userName);
        }

        public UserProfileResponse UpdateUserProfile(UserProfileEntity userProfile)
        {
            var userProfileResponse = new UserProfileResponse { Acknowledge = AcknowledgeType.Success };
            if (userProfile != null)
            {
                if (!userProfile.Validate())
                {
                    foreach (string error in userProfile.ValidationErrors)
                        userProfileResponse.Message += error + Environment.NewLine;
                    userProfileResponse.Acknowledge = AcknowledgeType.Failure;
                    return userProfileResponse;
                }

                if (string.IsNullOrEmpty(userProfile.UserProfileId))
                    userProfile.UserProfileId = Guid.NewGuid().ToString();

                var user = GetUserProfileByUserName(userProfile.UserName);
                if (user != null && !userProfile.UserProfileId.Equals(user.UserProfileId))
                {
                    userProfileResponse.Acknowledge = AcknowledgeType.Failure;
                    userProfileResponse.Message = string.Format("Tên đăng nhập \'{0}\' đã tồn tại!", userProfile.UserName);
                    return userProfileResponse;
                }

                userProfileResponse.Message = UserProfileDao.UpdateUserProfile(userProfile);
                userProfileResponse.RefId = userProfile.UserProfileId;

                if (!string.IsNullOrEmpty(userProfileResponse.Message))
                {
                    userProfileResponse.Acknowledge = AcknowledgeType.Failure;
                    return userProfileResponse;
                }
            }
            return userProfileResponse;
        }

        public UserProfileResponse DeleteUserProfile(string userProfileId)
        {
            var response = new UserProfileResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                response.Message = UserProfileDao.DeleteUserProfile(userProfileId);
                response.RefId = userProfileId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        //public UserProfileResponse GetUserProfiles(UserProfileRequest request)
        //{
        //    var response = new UserProfileResponse();

        //    if (request.LoadOptions.Contains("UserProfiles"))
        //    {
        //        response.UserProfiles = request.LoadOptions.Contains("Active") ? UserProfileDao.GetUserProfiles(request.IsActive) : UserProfileDao.GetUserProfiles();
        //    }
        //    if (request.LoadOptions.Contains("UserProfile"))
        //    {
        //        if (request.LoadOptions.Contains("UserProfileName"))
        //        {
        //            var userProfile = UserProfileDao.GetUserProfileByUserProfileName(request.UserProfileName, request.Password);
        //            if (userProfile == null)
        //            {
        //                response.Acknowledge = AcknowledgeType.Failure;
        //                response.Message = @"Tên đăng nhập hoặc mật khẩu không hợp lệ !";
        //                return response;
        //            }
        //            response.UserProfile = userProfile;
        //        }
        //        else
        //            response.UserProfile = UserProfileDao.GetUserProfile(request.UserProfileId);
        //    }

        //    return response;
        //}

        ///// <summary>
        ///// Sets the userProfiles.
        ///// </summary>
        ///// <param name="request">The request.</param>
        ///// <returns></returns>
        //public UserProfileResponse SetUserProfiles(UserProfileRequest request)
        //{
        //    var response = new UserProfileResponse();

        //    var userProfileEntity = request.UserProfile;
        //    if (request.Action != PersistType.Delete && userProfileEntity != null)
        //    {
        //        if (!userProfileEntity.Validate())
        //        {
        //            foreach (var error in userProfileEntity.ValidationErrors)
        //                response.Message += error + Environment.NewLine;
        //            response.Acknowledge = AcknowledgeType.Failure;
        //            return response;
        //        }
        //    }
        //    try
        //    {
        //        if (request.Action == PersistType.Insert)
        //        {
        //            if (userProfileEntity != null)
        //            {
        //                userProfileEntity.UserProfileId = UserProfileDao.InsertUserProfile(userProfileEntity);
        //                if (userProfileEntity.UserProfileId == 0)
        //                {
        //                    response.Acknowledge = AcknowledgeType.Failure;
        //                    return response;
        //                }
        //            }
        //        }
        //        else if (request.Action == PersistType.Update)
        //        {
        //            response.Message = UserProfileDao.UpdateUserProfile(userProfileEntity);
        //            if (response.Message != null)
        //            {
        //                response.Acknowledge = AcknowledgeType.Failure;
        //                return response;
        //            }
        //        }
        //        else if (request.Action == PersistType.Delete)
        //        {
        //            var userProfileForDelete = UserProfileDao.GetUserProfile(request.UserProfileId);
        //            response.Message = UserProfileDao.DeleteUserProfile(userProfileForDelete);
        //            if (response.Message != null)
        //            {
        //                response.Acknowledge = AcknowledgeType.Failure;
        //                response.RowsAffected = 0;
        //                return response;
        //            }
        //            response.RowsAffected = 1;
        //        }
        //        else
        //        {
        //            var userProfileForUpdate = UserProfileDao.GetUserProfileByUserProfileName(request.UserProfileName, request.OldPassword);
        //            if (userProfileForUpdate == null)
        //            {
        //                response.Acknowledge = AcknowledgeType.Failure;
        //                response.Message = @"Mật khẩu cũ không chính xác !";
        //                return response;
        //            }
        //            //assign new password
        //            userProfileForUpdate.Password = request.Password;
        //            response.Message = UserProfileDao.UpdateUserProfile(userProfileForUpdate);
        //            if (response.Message != null)
        //            {
        //                response.Acknowledge = AcknowledgeType.Failure;
        //                return response;
        //            }
        //            response.RowsAffected = 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Acknowledge = AcknowledgeType.Failure;
        //        response.Message = ex.Message;
        //        return response;
        //    }
        //    response.UserProfileId = userProfileEntity != null ? userProfileEntity.UserProfileId : 0;
        //    return response;
        //}
    }
}
