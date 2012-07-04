using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Form14242.Web.ViewModels
{
    public class Form14242Model
    {
        public int ID { get; set; }

        [DisplayName("1. a. Describe the suspected tax scheme being promoted")]
        public string SuspectedTaxScheme { get; set; }

        [DisplayName("b. Was the tax scheme promoted as a \"new\" legal tax strategy")]
        public bool? TaxSchemePromotedAsNewLegalTaxStrategy { get; set; }

        [DisplayName("2. How did you become aware of the promotion or promoter (Internet, email, TV, flyer, newspaper, magazine, friend, relative, etc.).")]
        public string HowBecameAwareOfPromotionOrPromoter { get; set; }

        [DisplayName("3. When did you first learn about the tax promotion (mm/dd/yyyy)")]
        public string DateLearnedAboutTaxPromotion { get; set; }

        [DisplayName("4. Promoter Information (If more than one promoter is involved, provide information on all promoters)")]
        public List<Promoter> Promoters { get; set; }

        [DisplayName("5. Describe the function/role of each person involved in the promotion")]
        public string DescriptionOfInvolvement { get; set; }

        [DisplayName("6. Do you have copies of any promotional material supplied by the promoter")]
        public bool? HaveCopiesOfPromotionalMaterial { get; set; }

        public List<Artifact> Artifacts { get; set; }

        [DisplayName("7. a. What was the cost for the promotional material")]
        public string CostForPromotionalMaterial { get; set; }

        [DisplayName("A monthly service fee")]
        public string CostIncludedMonthlyServiceFee { get; set; }

        [DisplayName("An audit protection fee")]
        public string CostIncludedAuditProtectionFee { get; set; }

        [DisplayName("8. How did you obtain the promotional information (Internet, mail, email, telephone solicitation, professional acquaintance, etc.).")]
        public string HowDidObtainPromotionalInformation { get; set; }

        [DisplayName("9. a. Did the promoter hold any seminars or meetings to promote the tax scheme")]
        public string PromoterHeldSeminarsToPromote { get; set; }

        [DisplayName("b. If you answered YES in 9a, what was the cost associated with attending the seminar or meeting")]
        public string CostAssociatedWithSeminar { get; set; }

        [DisplayName("c. Where was the seminar or meeting held")]
        public string LocationOfSeminar { get; set; }

        [DisplayName("d. When was the seminar or meeting held (mm/dd/yyyy)")]
        public string DateSeminarHeld { get; set; }

        [DisplayName("e. Did you personally attend any seminar or meeting associated with the promotion or promoter")]
        public bool? HasPersonallyAttendedSeminar { get; set; }

        [DisplayName("10. How is the promoter involved in the promotion (Describe promoters involvement)")]
        public string HowPromoterInvolved { get; set; }

        [DisplayName("11. Who is the target group of the promotion (Describe industry or type of taxpayer, i.e. nurse, policeman, home business, etc.)")]
        public string TargetedGroupOfPromotion { get; set; }

        [DisplayName("12. a. Are you aware of any similar promotions in your area")]
        public bool? AnyOtherPromotionsInArea { get; set; }

        [DisplayName("b. If YES, describe the other promotions and any similarities they have to this promotion")]
        public string AnyOtherPromotionsInAreaDescription { get; set; }

        [DisplayName("13. Is the promotion still being advertised")]
        public bool? PromotionStillBeingAdvertised { get; set; }

        [DisplayName("14. Describe the tax benefits of the promotion (Provide any information used to explain the tax benefits of the promotion)")]
        public string TaxBenifitsOfPromotion { get; set; }

        [DisplayName("15. Describe the geographic scope of the promotion. For example, is it restricted to a small area, nationwide, or worldwide")]
        public string GeographicScopeOfThePromotion { get; set; }

        [DisplayName("16. Do you know of any tax preparers completing returns for investors or promoters based upon this promotion")]
        public bool? AnyTaxPreparersCompletingReturns { get; set; }

        [DisplayName("If YES, provide the following information (if available) (If more than one preparer is involved, provide information on all preparers)")]
        public List<Preparer> Preparers { get; set; }

        [DisplayName("17. Did you have any private/personal conversations witht he promoter/accountant/return preparer/associate")]
        public bool? AnyPrivateConversations { get; set; }

        [DisplayName("With whom did you have a conversation")]
        public string WhomDidYouHaveConversation { get; set; }

        [DisplayName("What did they say during the conversation")]
        public string WhatWasSaidDuringConversation { get; set; }

        [DisplayName("Where did this conversation take place")]
        public string LocationOfConversation { get; set; }

        [DisplayName("When did this conversastion take place (mm/dd/yyy)")]
        public string DateOfConversation { get; set; }

        [DisplayName("When this conversation took place, if anyone else was present, list their names")]
        public string PeoplePresentDuringConversation { get; set; }

        [DisplayName("18. a. What is your current relationship with the promoter(s)")]
        public string CurrentRelationshipWithPromoter { get; set; }

        [DisplayName("b. Did you have personal/telephone contact with any of the promoters")]
        public bool? HadPersonalContactWithPromoter { get; set; }

        [DisplayName("19. Do you know any individuals/businesses that have purchased or used the promotion")]
        public bool? AnyPeoplePurchasePromotion { get; set; }

        [DisplayName("If YES, please provide their names")]
        public string NamesOfPeopleWhoPurchasedPromotion { get; set; }

        [DisplayName("20. a. Did you purchase and use the \"promotion package\"")]
        public bool? HasPurchasedAndUsedPromotion { get; set; }

        [DisplayName("b. If YES, have you amended your tax returns")]
        public bool? HasAmendedTaxReturns { get; set; }

        [DisplayName("Name")]
        public string ReporterName { get; set; }

        [DisplayName("Date Submitted")]
        public DateTime ReportedDate { get; set; }

        [DisplayName("Mailing address")]
        public string ReporterMailingAddress { get; set; }

        [DisplayName("Telephone number")]
        public string ReporterTelephoneNumber { get; set; }

        [DisplayName("Email address")]
        public string ReporterEmailAddress { get; set; }

    }
}