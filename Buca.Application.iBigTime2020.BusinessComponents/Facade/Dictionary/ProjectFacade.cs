/***********************************************************************
 * <copyright file="ProjectFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Linq;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class ProjectFacade
    {
        private static readonly IProjectDao ProjectDao = DataAccess.DataAccess.ProjectDao;
        private static readonly IBankDao BankDAO = DataAccess.DataAccess.BankDao;
        //private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        public ProjectEntity GetProject(string projectId)
        {
            return ProjectDao.GetProject(projectId);
        }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        public List<ProjectEntity> GetProjects()
        {
            return ProjectDao.GetProjects();
        }

        /// <summary>
        /// Gets the projects by project code.
        /// </summary>
        /// <param name="projectCode">The project code.</param>
        /// <returns></returns>
        public List<ProjectEntity> GetProjectsByProjectCode(string projectCode)
        {
            return ProjectDao.GetProjectsByProjectCode(projectCode);
        }
        /// <summary>
        /// Gets the projects by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<ProjectEntity> GetProjectsByActive(bool isActive)
        {
            return ProjectDao.GetProjectsByActive(isActive);
        }

        public List<ProjectEntity> GetProjectsByObjectType(string objectType)
        {
            return ProjectDao.GetProjectsByObjectType(objectType);
        }
        /// <summary>
        /// Inserts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public ProjectResponse InsertProject(ProjectEntity project)
        {
            var response = new ProjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var projects = ProjectDao.GetProjectsByProjectCodeObjectType(project.ProjectCode, project.ObjectType);
                if (projects != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    switch (project.ObjectType)
                    {
                        case 1:
                            response.Message = @"Mã CTMT " + project.ProjectCode + @" đã tồn tại!";
                            break;
                        case 2:
                            response.Message = @"Mã dự án " + project.ProjectCode + @" đã tồn tại!";
                            break;
                        case 3:
                            response.Message = @"Mã HMCT " + project.ProjectCode + @" đã tồn tại!";
                            break;
                    }

                    return response;
                }
                if (!project.Validate())
                {
                    foreach (string error in project.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                project.ProjectId = Guid.NewGuid().ToString();
                response.Message = ProjectDao.InsertProject(project);
                #region insert bank
                if (project.ProjectBanks.Count() > 0)
                {
                    project.ProjectBanks.ForEach(item =>
                    {
                        var bank = new BankEntity()
                        {
                            BankId = Guid.NewGuid().ToString(),
                            BankAccount = item.BankAccount,
                            BankName = item.BankName,
                            IsActive = true,
                            ProjectId = project.ProjectId,
                            IsOpenInBank = true
                        };
                        BankDAO.InsertBank(bank);
                    });
                }
                #endregion
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ProjectId = project.ProjectId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public ProjectResponse InsertProjectConvert(ProjectEntity project)
        {
            var response = new ProjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var projects = ProjectDao.GetProjectsByProjectCodeObjectType(project.ProjectCode, project.ObjectType);
                if (projects != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    switch (project.ObjectType)
                    {
                        case 1:
                            response.Message = @"Mã CTMT " + project.ProjectCode + @" đã tồn tại!";
                            break;
                        case 2:
                            response.Message = @"Mã dự án " + project.ProjectCode + @" đã tồn tại!";
                            break;
                        case 3:
                            response.Message = @"Mã HMCT " + project.ProjectCode + @" đã tồn tại!";
                            break;
                    }

                    return response;
                }
                if (!project.Validate())
                {
                    foreach (string error in project.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = ProjectDao.InsertProject(project);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ProjectId = project.ProjectId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public ProjectResponse UpdateProject(ProjectEntity project,bool editBank = false)
        {
            var response = new ProjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var projects = ProjectDao.GetProjectsByProjectCodeObjectType(project.ProjectCode.Trim(), project.ObjectType);

                if ((projects != null) && projects.ProjectId != project.ProjectId)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    switch (project.ObjectType)
                    {
                        case 1:
                            response.Message = @"Mã CTMT " + project.ProjectCode.Trim() + @" đã tồn tại!";
                            break;
                        case 2:
                            response.Message = @"Mã dự án " + project.ProjectCode.Trim() + @" đã tồn tại!";
                            break;
                        case 3:
                            response.Message = @"Mã HMCT " + project.ProjectCode.Trim() + @" đã tồn tại!";
                            break;
                    }

                    return response;
                }

                if (!project.Validate())
                {
                    foreach (string error in project.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = ProjectDao.UpdateProject(project);
                // lay ra danh sach bank cu
                if (editBank)
                {
                    var oldBanks = BankDAO.GetProjectBank(project.ProjectId);
                    oldBanks = oldBanks.Where(o => project.ProjectBanks.Count() == 0 || !project.ProjectBanks.Any(pb => o.BankId == pb.BankId)).ToList();
                    if (oldBanks.Count() > 0)
                    {
                        for (var i = 0; i < oldBanks.Count(); i++)
                        {
                            var bank = oldBanks[i];
                            response.Message = BankDAO.DeleteBank(bank);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                if (response.Message.Contains("FK"))
                                {
                                    response.Message = @"Bạn không thể xóa tài khoản " + bank.BankAccount + " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                                }
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }
                    };
                    #region insert bank
                    if (project.ProjectBanks.Count() > 0)
                    {
                        project.ProjectBanks.ForEach(item =>
                        {
                            if (item.BankId == null || item.BankId == Guid.Empty.ToString())
                            {
                                var bank = new BankEntity()
                                {
                                    BankId = Guid.NewGuid().ToString(),
                                    BankAccount = item.BankAccount,
                                    BankName = item.BankName,
                                    IsActive = true,
                                    ProjectId = project.ProjectId,
                                    IsOpenInBank = true,
                                    SortBank = item.SortBank,
                                };
                                BankDAO.InsertBank(bank);
                            }
                            else
                            {
                                var bank = new BankEntity()
                                {
                                    BankId = item.BankId,
                                    BankAccount = item.BankAccount,
                                    BankName = item.BankName,
                                    IsActive = true,
                                    ProjectId = project.ProjectId,
                                    IsOpenInBank = true,
                                    SortBank = item.SortBank,
                                };
                                BankDAO.UpdateBank(bank);
                            }

                        });
                    }
                }
              
                #endregion
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ProjectId = project.ProjectId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns></returns>
        public ProjectResponse DeleteProject(string projectId)
        {
            var response = new ProjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var project = ProjectDao.GetProject(projectId);
                var projects = ProjectDao.GetProjects().Where(x => x.ParentID == projectId).ToList();

                if (projects.Count != 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;

                    switch (project.ObjectType)
                    {
                        case 1:
                            response.Message = @"Bạn phải xóa tất cả các CTMT con trước khi xóa CTMT cha";
                            break;
                        case 2:
                            response.Message = @"Bạn phải xóa tất cả các dự án con trước khi xóa dự án cha";
                            break;
                        case 3:
                            response.Message = @"Bạn phải xóa tất cả các HMCT con trước khi xóa HMCT cha";
                            break;
                    }
                    return response;
                }

                response.Message = ProjectDao.DeleteProject(projectId);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK")
                        )
                        response.Message = @"Bạn không thể xóa dự án,CTMT,HMCT " + project.ProjectCode + " , vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ProjectId = projectId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public ProjectResponse DeleteProjectConvert()
        {
            var response = new ProjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {


                response.Message = ProjectDao.DeleteProjectConvert();

                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

    }
}
