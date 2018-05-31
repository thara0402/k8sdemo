using System;
using System.ComponentModel.DataAnnotations;

namespace k8sdemo.Controllers
{

    /// <summary>
    /// Person Model
    /// </summary>
    public class Person
    {
        
        /// <summary>
        /// Person ID
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }

        /// <summary>
        /// Person Code
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Person Name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }        
    }
}