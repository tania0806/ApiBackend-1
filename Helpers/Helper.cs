using System;
using reportesApi.Models;

namespace reportesApi.Helpers
{
    public class Helper
    {
        public Helper()
        {
        }
        // Returns structure for Json Response
        public static DataResponse GetStructResponse()
        {
            return new DataResponse
            {
                StatusCode=0,
                success = false,
                message = "",
              
                response = new { data = "" }

            };
        }
    }
}
