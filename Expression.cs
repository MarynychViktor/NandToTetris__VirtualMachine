namespace VirtualMachine
{
    public  interface IExpressionVisitor
    {
        public abstract object VisitPushExpression(Expression.PushExpression expression);
        public abstract object VisitPopExpression(Expression.PopExpression expression);
        public abstract object VisitCommandExpression(Expression.CommandExpression expression);
    }

    public abstract class Expression
    {
        public abstract object Accept(IExpressionVisitor visitor);

        public class PushExpression : Expression
        {
            public SegmentType Segment { get; set; }
            public int Address { get; set; }

            public PushExpression(SegmentType segment, int address)
            {
                Segment = segment;
                Address = address;
            }

            public override object Accept(IExpressionVisitor visitor)
            {
                return visitor.VisitPushExpression(this);
            }
        }
        
        public class PopExpression : Expression
        {
            public SegmentType Segment { get; set; }
            public int Address { get; set; }

            public PopExpression(SegmentType segment, int address)
            {
                Segment = segment;
                Address = address;
            }
            
            public override object Accept(IExpressionVisitor visitor)
            {
                return visitor.VisitPopExpression(this);
            }
        }
                
        public class CommandExpression : Expression
        {
            public  TokenType type { get; set; }

            public CommandExpression(TokenType type)
            {
                type = type;
            }
            
            public override object Accept(IExpressionVisitor visitor)
            {
                return visitor.VisitCommandExpression(this);
            }
        }
    }
}