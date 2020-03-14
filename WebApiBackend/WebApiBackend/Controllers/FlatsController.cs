using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBackend.Dto;
using WebApiBackend.Model;

namespace WebApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly FlatManagementContext _context;
        private static readonly IMapper _MemberMapper;

        //Create mapper using Automapper
        static FlatController()
        {
            var mapperConfigure = new MapperConfiguration(
                config =>
                {
                    config.CreateMap<User, DisplayMemberDTO>();
                    config.CreateMap<User, MemberDetailDTO>();
                }

            );
            _MemberMapper = mapperConfigure.CreateMapper();
        }


        public FlatController(FlatManagementContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        [HttpGet("display/{flatId}")]
        public ActionResult<List<DisplayMemberDTO>> GetMembers(int flatId)
        {
            Flat flat = _context.Flat.Where(f => f.Id == flatId).FirstOrDefault();
            IQueryable members = _context.Entry(flat).Collection(f => f.Users).Query().OrderBy(u => u.FirstName);
            return _MemberMapper.Map<List<DisplayMemberDTO>>(members);
        }

        [AllowAnonymous]
        [HttpGet("detail/{username}")]
        public ActionResult<MemberDetailDTO> GetMemberFullDetail(string username)
        {
            User member = _context.User.Find(username);
            if (member == null)
            {
                return NotFound();
            }

            return _MemberMapper.Map<MemberDetailDTO>(member);
        }


    }
}
