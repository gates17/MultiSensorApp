#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiSensorAppApi.Data;
using MultiSensorAppApi.Models;

namespace MultiSensorAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("GetProfileById/{id}")]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            var profile = await _context.Profiles.Include(p => p.Area).Include(p => p.Category).Include(p => p.Role).Include(p => p.Permission).FirstAsync();

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        //Get: api/Profile/5
        [HttpGet("GetProfileByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfileByCategory(int categoryId)
        {
            try
            {
                var profile = await _context.Profiles.Where(x => x.CategoryId == categoryId).ToListAsync();

                if (profile is null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        //Get: api/Profile/5
        [HttpGet("GetProfileByArea/{areaId}")]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfileByArea(int areaId)
        {
            try
            {
                var profile = await _context.Profiles.Where(x => x.AreaId == areaId).ToListAsync();

                if (profile is null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        //Get: api/Profile/5
        [HttpGet("GetProfileByRole/{roleId}")]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfileByRole(int roleId)
        {
            try
            {
                var profile = await _context.Profiles.Where(x => x.RoleId == roleId).ToListAsync();

                if (profile is null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        //Get: api/Profile/5
        [HttpGet("GetProfileByPermission/{permissionId}")]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfileByPermission(int permissionId)
        {
            try
            {
                var profile = await _context.Profiles.Where(x => x.PermissionId == permissionId).ToListAsync();

                if (profile is null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            try
            {
                _context.Profiles.Add(profile);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProfileById", new { id = profile.Id }, profile);

            }
            // fazermos as nossas exceções!!
            catch (BadHttpRequestException)
            {

                throw new BadHttpRequestException("e");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            profile.IsInactive = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
