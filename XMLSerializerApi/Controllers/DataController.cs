using Optional;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using XMLSerializerApi.Helpers;
using XMLSerializerApi.Models;
using XMLSerializerApi.Store.Data;
using XMLSerializerCommon.Models;

namespace XMLSerializerApi.Controllers
{
    public class DataController : ApiController
    {
        private readonly IDataStore _dataStore;

        public DataController(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        /// <summary>
        /// This method runs specific Job, to get data from database and then writes them in XML files.
        /// </summary>
        /// <remarks>The database must have loaded data. Only unique data will be writes them in XML file.</remarks>
        /// <response code="200">Data was loaded with success.</response>
        /// <response code="500">Internal Server Error - data was saved in XML file.</response>
        [HttpGet]
        [Route("api/jobs/saveFiles")]
        public IHttpActionResult SaveFiles()
        {
            Option<bool, Exception> resultOptionBool = _dataStore.UpdoadData();
            bool isSucces = resultOptionBool.ValueOr(false);

            if (isSucces)
                return Ok("Data was loaded with success.");
            else
                return InternalServerError(new Exception("Internal Server Error - data was saved in XML file."));
        }

        /// <summary>
        /// Retrieves a specific visits data and stores them in database.
        /// </summary>
        /// <remarks>Only new unique data will be added.</remarks>
        /// <response code="200">Data was Updated with success.</response>
        /// <response code="400">Received data was incorrect or empty.</response>
        /// <response code="500">Internal Server Error - data was not added to database.</response>
        [HttpPost]
        [Route("api/data")]
        public IHttpActionResult UpdoadData([FromBody][Required]List<RequestApiModel> requestApiModel)
        {
            if (ModelState.IsValid && requestApiModel != null)
            {
                List<RequestModel> requestModel = ResponseModelConverter.Convert(requestApiModel);

                Option<bool, Exception> resultOptionBool = _dataStore.SaveData(requestModel);
                bool isSucces = resultOptionBool.ValueOr(false);

                if (isSucces)
                    return Ok("Data was Updated with success.");
                else
                {
                    Exception exception = resultOptionBool.ExceptionOr(() => throw new InvalidOperationException("Internal Server Error - data was not added to database."));
                    return InternalServerError(new Exception(exception.Message));
                }
            }
            else
            {
                return BadRequest("Received data was incorrect or empty.");
            }
        }
    }
}