using Microsoft.AspNetCore.Mvc;
using Rotina.Domain.Commands;
using Rotina.DomainService.IServices;
using System;
using System.Threading.Tasks;

namespace Rotina.Web.Controllers
{
    public class UserController : GenericController
    {
        private readonly IUserService _svcUser;

        public UserController(IMessageService svcMessage, IUserService svcUser) : base(svcMessage)
        {
            _svcUser = svcUser;
        }

        #region Add

        [HttpPost]
        public async Task<JsonResult> Add([FromBody] UserCommand body)
        {
            try
            {
                await _svcUser.Add(body);

                return Success(1);
            }
            catch (Exception ex)
            {
                return await Error(ex);
            }
        }

        #endregion

        #region Update

        [HttpPut]
        public async Task<JsonResult> Update([FromBody] UserCommand body)
        {
            try
            {
                await _svcUser.Add(body);

                return Success(1);
            }
            catch (Exception ex)
            {
                return await Error(ex);
            }
        }

        #endregion

        #region Delete

        [HttpDelete]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                await _svcUser.Delete(id);

                return Success(1);
            }
            catch (Exception ex)
            {
                return await Error(ex);
            }
        }

        #endregion

        #region Get

        [HttpGet]
        [Route("FindById")]
        public async Task<JsonResult> FindById(string id)
        {
            try
            {
                return Success(await _svcUser.FindById(id));
            }
            catch (Exception ex)
            {
                return await Error(ex);
            }
        }

        [HttpGet]
        [Route("FindByEmail")]
        public async Task<JsonResult> FindByEmail(string email)
        {
            try
            {
                return Success(await _svcUser.FindByEmail(email));
            }
            catch (Exception ex)
            {
                return await Error(ex);
            }
        }

        #endregion
    }
}
