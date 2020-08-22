namespace GradeBook.GradeBooks
{
    using GradeBook.Enums;

    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }
    }
}