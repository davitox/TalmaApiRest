using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talma.UnitTest
{
    public class StudentRepositoryTests
    {
        private readonly Mock<ModelContext> _mockContext;
        private readonly IStudentRepository _studentRepository;

        public StudentRepositoryTests()
        {
            _mockContext = new Mock<ModelContext>();
            _studentRepository = new StudentRepository( _mockContext.Object );
        }

        [Fact]
        public async Task GetStudentById_WhenStudentExists()
        {
            var Id = 44;
            var student = new Estudiante { Id = Id };

            _mockContext.Setup(c => c.Estudiante.FindAsync(Id)).ReturnsAsync(student);

            var result = await _studentRepository.GetStudentByIdAsync( Id );

            Assert.NotNull( result );
            Assert.Equal( Id, result.Id );

        }
    }
}
