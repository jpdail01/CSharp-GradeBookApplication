namespace GradeBook.GradeBooks
{
    using GradeBook.Enums;

    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Standard;

        }
    }
}