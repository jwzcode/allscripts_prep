using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Where<ItemToMatch>
    {
        public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
            Func<ItemToMatch, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>

        {
            return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(property_accessor,
                has_a(property_accessor), new MatchCreator<ItemToMatch>());
        }

        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            Func<ItemToMatch, PropertyType> property_accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(property_accessor, new MatchCreator<ItemToMatch>());
        }
    }
}