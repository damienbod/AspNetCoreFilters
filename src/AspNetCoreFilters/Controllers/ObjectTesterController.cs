using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFilters.Controllers
{
    [Route("api/[controller]")]
    public class ObjectTesterController : Controller
    {
        [HttpGet]
        [Route("tarray")]
        public IActionResult GetArrayObject()
        {
            var data = new TestNestedDocumentLevelOneArray
            {
                DescriptionOne = "D1",
                Id = 1,
                TestNestedDocumentLevelTwoArray = new TestNestedDocumentLevelTwoArray[]
                    {
                        new TestNestedDocumentLevelTwoArray
                        {
                            DescriptionTwo = "D2",
                            Id=1,
                            TestNestedDocumentLevelOneArray = new TestNestedDocumentLevelOneArray{
                                Id=1,
                                DescriptionOne="D1",
                                TestNestedDocumentLevelTwoArray = new TestNestedDocumentLevelTwoArray[]
                                {
                                    new TestNestedDocumentLevelTwoArray
                                    {
                                        DescriptionTwo="D1",
                                        Id=1
                                    }
                                }
                            },
                            TestNestedDocumentLevelThreeArray = new TestNestedDocumentLevelThreeArray
                            {
                                DescriptionThree = "D3",
                                Id=1,
                                TestNestedDocumentLevelFourArray = new TestNestedDocumentLevelFourArray[]
                                {
                                    new TestNestedDocumentLevelFourArray
                                    {
                                        DescriptionFour="D4", Id=1,
                                        TestNestedDocumentLevelThreeArray = new TestNestedDocumentLevelThreeArray
                                        {
                                            DescriptionThree="D3"
                                        }
                                    },
                                    new TestNestedDocumentLevelFourArray
                                    {
                                        DescriptionFour="D4", Id=2,
                                        TestNestedDocumentLevelThreeArray = new TestNestedDocumentLevelThreeArray
                                        {
                                            DescriptionThree="D3"
                                        }
                                    }
                                }
                            }
                        }
                    }
            };

            return Ok(data);
        }

        [HttpPost]
        [Route("tarray")]
        public IActionResult PostArrayObject(TestNestedDocumentLevelOneArray model)
        {
            var data = model;
            return Ok("created");
        }

    }
    public class TestNestedDocumentLevelOneArray
    {
        public long Id { get; set; }
        public string DescriptionOne { get; set; }

        public virtual TestNestedDocumentLevelTwoArray[] TestNestedDocumentLevelTwoArray { get; set; }
    }

    public class TestNestedDocumentLevelTwoArray
    {
        public long Id { get; set; }
        public string DescriptionTwo { get; set; }

        public virtual TestNestedDocumentLevelOneArray TestNestedDocumentLevelOneArray { get; set; }
        public virtual TestNestedDocumentLevelThreeArray TestNestedDocumentLevelThreeArray { get; set; }
    }

    public class TestNestedDocumentLevelThreeArray
    {
        public long Id { get; set; }
        public string DescriptionThree { get; set; }

        public virtual TestNestedDocumentLevelTwoArray[] TestNestedDocumentLevelTwoArray { get; set; }

        public virtual TestNestedDocumentLevelFourArray[] TestNestedDocumentLevelFourArray { get; set; }
    }

    public class TestNestedDocumentLevelFourArray
    {
        public long Id { get; set; }
        public string DescriptionFour { get; set; }

        public virtual TestNestedDocumentLevelThreeArray TestNestedDocumentLevelThreeArray { get; set; }
    }
}
