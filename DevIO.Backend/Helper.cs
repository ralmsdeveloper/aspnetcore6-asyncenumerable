using Bogus;
using DevIO.Shared.Data;

namespace DevIO.Backend
{
    public static class Helper
    {
        public static List<Pessoa> GetPessoas()
        {
            var pessoas = new List<Pessoa>();

            for (int i = 0; i < 10; i++)
            {
                var fake = new Faker<Bogus.Person>()
                    .CustomInstantiator(p => new Bogus.Person())
                    .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
                    .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName).ToLower())
                    .Generate(); 

                pessoas.Add(new()
                {
                    Nome = fake.FullName,
                    Email = fake.Email,
                    Foto = fake.Avatar
                });
            }

            return pessoas;
        } 
    }
}
