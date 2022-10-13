using Session3.DataModels;
using System;
using System.Collections.Generic;

namespace Session3.Tests
{
    class PetData
    {
        public static PetModel demoPet()
        {
            var random = new Random();
            int randomId = random.Next(100, 1000);

            List<Tags> tags = new List<Tags>();
            tags.Add(new Tags()
            {
                Id = randomId,
                Name = "Orange_Tag"
            });

            return new PetModel
            {
                Id = randomId,
                Name = "Tommy",
                PhotoUrls = new List<string> { "Photo_String" },
                Category = new Category()
                {
                    Id = randomId,
                    Name = "Cat"
                },
                Tags = tags,
                Status = "available"
            };
        }
    }
}
