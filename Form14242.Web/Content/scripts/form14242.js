function Promoter() {
    var self = this;
    self.sequence = ko.observable();
    self.promoterName = ko.computed(function () {
        return "Promoters[" + self.sequence() + "].";
    }, self);
}

function Preparer() {
    var self = this;
    self.sequence = ko.observable();
    self.preparerName = ko.computed(function () {
        return "Preparers[" + self.sequence() + "].";
    }, self);
}

function PromotionalMaterial() {
    var self = this;
    self.sequence = ko.observable();
    self.promotionalMaterialName = ko.computed(function () {
        return "PromotionalMaterials[" + self.sequence() + "].FileUpload";
    }, self);
}

function Form14242() {
    var self = this;
    // Promoters
    self.Promoters = ko.observableArray([]);
    self.addPromoter = function () {
        self.Promoters.push(new Promoter());
    };
    self.removePromoter = function (promoter) {
        self.Promoters.remove(promoter);
    };
    self.canRemovePromoter = ko.computed(function () {
        return !!(self.Promoters() && self.Promoters().length > 1);
    }, self);
    self.Promoters.subscribe(function () {
        var promoters = self.Promoters();
        if (promoters) {
            for (var i = 0, max = promoters.length; i < max; i++) {
                promoters[i].sequence(i);
            }
        }
    }, self);

    // Preparers
    self.Preparers = ko.observableArray([]);
    self.addPreparer = function () {
        self.Preparers.push(new Preparer());
    };
    self.removePreparer = function (preparer) {
        self.Preparers.remove(preparer);
    };
    self.canRemovePreparer = ko.computed(function () {
        return !!(self.Preparers() && self.Preparers().length > 1);
    }, self);
    self.Preparers.subscribe(function () {
        var preparers = self.Preparers();
        if (preparers) {
            for (var i = 0, max = preparers.length; i < max; i++) {
                preparers[i].sequence(i);
            }
        }
    }, self);

    // Promotional Material
    self.isPromotionalMaterial = ko.observable();
    self.PromotionalMaterial = ko.observableArray([]);
    self.addPromotionalMaterial = function () {
        self.PromotionalMaterial.push(new PromotionalMaterial());
    };
    self.removePromotionalMaterial = function (promotionalMaterial) {
        self.PromotionalMaterial.remove(promotionalMaterial);
    };
    self.PromotionalMaterial.subscribe(function () {
        var pm = self.PromotionalMaterial();
        if (pm) {
            for (var i = 0, max = pm.length; i < max; i++) {
                pm[i].sequence(i);
            }
        }
    }, self);

    // misc properties
    self.isSeminarsHeld = ko.observable();
    self.isOtherPromotionsInArea = ko.observable();
    self.isAnyTaxPreparersCompletingReturns = ko.observable();
    self.isAnyPrivateConversations = ko.observable();
    self.isAnyPeoplePurchasePromotion = ko.observable();
    self.hasPurchasedAndUsedPromotion = ko.observable();

    // events
    self.afterAdd = function (element, index, promo) {
        if (element && element.nodeType === 1) {
            $(element).hide().slideDown();
        }
    }
    self.beforeRemove = function (element, index, promo) {
        if (element && element.nodeType === 1) {
            var $elem = $(element);
            $elem.animate({ opacity: .1 }, 300, function () {
                $elem.slideUp(function () { $elem.remove(); });
            });
        }
    }

    function _init() {
        self.addPromoter();
        self.addPreparer();
        self.addPromotionalMaterial();
    }

    _init();
}