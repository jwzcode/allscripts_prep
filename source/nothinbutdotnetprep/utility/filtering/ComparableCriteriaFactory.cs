using System;

namespace nothinbutdotnetprep.utility.filtering
{

    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> : ICreateSpecifications<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToMatch, PropertyType> property_accessor;
        ICreateSpecifications<ItemToMatch, PropertyType> original_factory;
        private IMatchCreator<ItemToMatch> match_creator;
 
        public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> property_accessor,ICreateSpecifications<ItemToMatch,PropertyType> original_factory, IMatchCreator<ItemToMatch> match_creator )
        {
            this.property_accessor = property_accessor;
            this.original_factory = original_factory;
            this.match_creator = match_creator;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return original_factory.equal_to(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] possible_values)
        {
            return original_factory.equal_to_any(possible_values);
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return original_factory.not_equal_to(value);
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            return match_creator.create_match(x => property_accessor(x).CompareTo(value) > 0);

            //return new AnonymousMatch<ItemToMatch>(x => property_accessor(x).CompareTo(value) > 0);
        }

        public IMatchAn<ItemToMatch> between(PropertyType begin_value, PropertyType end_value)
        {

            return match_creator.create_match(
                x =>
                        (property_accessor(x).CompareTo(begin_value) >= 0 &&
                            property_accessor(x).CompareTo(end_value) <= 0));
            /*
            return
                new AnonymousMatch<ItemToMatch>(
                    x =>
                        (property_accessor(x).CompareTo(begin_value) >= 0 &&
                            property_accessor(x).CompareTo(end_value) <= 0));
             */
        }
    }
}