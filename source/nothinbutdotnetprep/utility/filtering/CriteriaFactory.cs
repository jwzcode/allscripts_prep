using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> property_accessor;
        private IMatchCreator<ItemToMatch> match_creator;
        public CriteriaFactory(Func<ItemToMatch, PropertyType> property_accessor, IMatchCreator<ItemToMatch> match_creator )
        {
            this.property_accessor = property_accessor;
            this.match_creator = match_creator;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return
                match_creator.create_match(x => new List<PropertyType>(possible_values).Contains(property_accessor(x)));
            /*
            return
                new AnonymousMatch<ItemToMatch>(
                    x => new List<PropertyType>(possible_values).Contains(property_accessor(x)));
             */
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }
    }
}