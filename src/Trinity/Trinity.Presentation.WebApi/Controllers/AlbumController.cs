using System;
using Microsoft.AspNetCore.Mvc;
using Trinity.Application.Interfaces;
using Trinity.Application.Model;

namespace Trinity.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        readonly IAlbumAppService App;

        public AlbumController(IAlbumAppService app)
        {
            App = app;
        }

        /// <summary>
        /// Gets all albums
        /// </summary>
        /// 
        /// <returns>Album list</returns>
        /// 
        ///<response code="200">Returns the items</response>
        ///<response code="500">Returns an internal server error</response>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, App.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Gets one specific album
        /// </summary>
        /// 
        /// <param name="id">Identifier</param>
        /// 
        /// <returns></returns>
        ///
        ///<response code="200">Returns the found album</response>
        ///<response code="404">If there's no one album that matches the identifier</response>
        ///<response code="500">Returns an internal server error</response>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                return StatusCode(200, App.Get(id));
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(404, ex.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Creates a Album
        /// </summary>
        /// 
        /// <param name="model"></param>
        /// 
        /// <returns>A newly created Album</returns>
        ///
        ///<response code="201">Returns the newly created item</response>
        ///<response code="400">Returns the validation errors</response>
        ///<response code="500">Returns an internal server error</response>
        [HttpPost]
        public IActionResult Post([FromBody] AlbumInsertingModel model)
        {
            try
            {
                return StatusCode(201, App.Create(model));
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.ToString());
            }
            catch (InternalServerException ex)
            {
                return StatusCode(500, ex.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Updates a album
        /// </summary>
        /// 
        /// <param name="model"></param>
        /// 
        /// <returns>Updated album</returns>
        ///
        ///<response code="201">Returns the newly created item</response>
        ///<response code="400">Returns the validation errors</response>
        ///<response code="404">If there's no one album that matches the model's identifier</response>
        ///<response code="500">Returns an internal server error</response>
        [HttpPut]
        public IActionResult Put([FromBody] AlbumUpdatingModel model)
        {
            try
            {
                return StatusCode(200, App.Update(model));
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(404, ex.ToString());
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.ToString());
            }
            catch (InternalServerException ex)
            {
                return StatusCode(500, ex.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Deletes a album
        /// </summary>
        /// 
        /// <param name="id">Identifier</param>
        /// 
        /// <returns>A no-content result</returns>
        ///
        ///<response code="204">No content to return if the album was deleted</response>
        ///<response code="404">If there's no one album that matches the identifier</response>
        ///<response code="500">Returns an internal server error</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                App.Delete(id);
                return StatusCode(204);
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(404, ex.ToString());
            }
            catch (InternalServerException ex)
            {
                return StatusCode(500, ex.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
