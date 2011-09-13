using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public interface ICreateSpecifications<ItemToMatch, PropertyType>
    {
        IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal);
        IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] possible_values);
        IMatchAn<ItemToMatch> not_equal_to(PropertyType value);
    }

    public interface IMatchCreator<ItemToMatch>
    {
        IMatchAn<ItemToMatch> create_match(Predicate<ItemToMatch> condition);
    }

    public class MatchCreator<ItemToMatch> : IMatchCreator<ItemToMatch>
    {

        public IMatchAn<ItemToMatch> create_match(Predicate<ItemToMatch> condition)
        {
            return new AnonymousMatch<ItemToMatch>(condition);
        }
    }
}