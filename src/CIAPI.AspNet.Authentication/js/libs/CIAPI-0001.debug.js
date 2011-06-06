var CIAPI = CIAPI || {};

/**
    @namespace Test data
*/
CIAPI.__testData = (function() {
   try {
       var
        _i, _j,
        _marketList = [],
        _priceBars = {},
       _currentBar, _currentMarket,

       /**
        * @private
        */
        _generateNextPrice = function (lastPrice) {
            var direction = Math.random() > 0.5 ? 1 : -1;
            return lastPrice.Close + (direction * lastPrice.Close * 0.05);
        },
       /**
        * @private
        */
        _createPriceBar = function(previousBar, interval) {
            var intervalInMs = {
                minute: 1000 * 60,
                hour:  1000 * 60 * 60,
                day: 1000 * 60 * 60 * 24
            };
            var theDate = new Date(previousBar.BarDate.getTime() - intervalInMs[interval]);
            var close = _generateNextPrice(previousBar);
            return {
                "BarDate":theDate,
                "Close": close,
                "High": close * (Math.random() + 1),
                "Low":close * (1- Math.random()),
                "Open":previousBar.Close
            };
        };


        for (_i = 0; _i <= 100; _i++) {
            _currentBar = {
                "BarDate":new Date(),
                "Close":1.6283,
                "High":1.6285,
                "Low":1.6283,
                "Open":1.6284
            };
            _currentMarket = {
                "MarketId": _i,
                "Name": "{marketName} CFD #" + (_i + 1),
                "PriceHistory": {
                    minute: []
                }
            };
            for (_j = 0; _j <= 1000; _j++) {
                _currentMarket.PriceHistory.minute.push(_currentBar);
                _currentBar = _createPriceBar(_currentBar, 'minute');
            }
            _marketList.push(_currentMarket);
        }
        return {
            MarketList: _marketList
        };
    }
    catch(error) {
       /*console.log(error)*/;
    }
})();var CIAPI = CIAPI || {};
CIAPI.dojo = {};

(function(){
    var d = CIAPI.dojo, opts = Object.prototype.toString;

    d.isArray = function(/*anything*/ it){
		//	summary:
		//		Return true if it is an Array.
		//		Does not work on Arrays created in other windows.
		return it && (it instanceof Array || typeof it == "array"); // Boolean
	};

    d.isFunction = function(/*anything*/ it){
		// summary:
		//		Return true if it is a Function
		return opts.call(it) === "[object Function]";
	};

    d._extraNames = extraNames = extraNames || ["hasOwnProperty", "valueOf", "isPrototypeOf",
		"propertyIsEnumerable", "toLocaleString", "toString", "constructor"];
    var extraNames = d._extraNames, extraLen = extraNames.length, empty = {};
    d.clone = function(/*anything*/ o) {
        // summary:
        //		Clones objects (including DOM nodes) and all children.
        //		Warning: do not clone cyclic structures.
        if (!o || typeof o != "object" || d.isFunction(o)) {
            // null, undefined, any non-object, or function
            return o;	// anything
        }
        if (o.nodeType && "cloneNode" in o) {
            // DOM Node
            return o.cloneNode(true); // Node
        }
        if (o instanceof Date) {
            // Date
            return new Date(o.getTime());	// Date
        }
        if (o instanceof RegExp) {
            // RegExp
            return new RegExp(o);   // RegExp
        }
        var r, i, l, s, name;
        if (d.isArray(o)) {
            // array
            r = [];
            for (i = 0,l = o.length; i < l; ++i) {
                if (i in o) {
                    r.push(d.clone(o[i]));
                }
            }
// we don't clone functions for performance reasons
//		}else if(d.isFunction(o)){
//			// function
//			r = function(){ return o.apply(this, arguments); };
        } else {
            // generic objects
            r = o.constructor ? new o.constructor() : {};
        }
        for (name in o) {
            // the "tobj" condition avoid copying properties in "source"
            // inherited from Object.prototype.  For example, if target has a custom
            // toString() method, don't overwrite it with the toString() method
            // that source inherited from Object.prototype
            s = o[name];
            if (!(name in r) || (r[name] !== s && (!(name in empty) || empty[name] !== s))) {
                r[name] = d.clone(s);
            }
        }
        // IE doesn't recognize some custom functions in for..in
        if (extraLen) {
            for (i = 0; i < extraLen; ++i) {
                name = extraNames[i];
                s = o[name];
                if (!(name in r) || (r[name] !== s && (!(name in empty) || empty[name] !== s))) {
                    r[name] = s; // functions only, we don't clone them
                }
            }
        }
        return r; // Object
    };

})();/**
    @namespace CityIndex API javascript client library
*/
var CIAPI = CIAPI || {};
CIAPI.version = "0.1";


var CIAPI = CIAPI || {};

CIAPI.log = function(message) {
    /*console.log(message)*/;
};var CIAPI = CIAPI || {};

/**
    @namespace A collection of services that you can call
*/
CIAPI.services = (function() {

    return {
        /**
         * Search for markets of type CFD
         * @param searchByMarketName
         * @param searchByMarketCode
         * @param maxResults
         */
        ListCfdMarkets: function(searchByMarketName, searchByMarketCode, maxResults) {
            if (maxResults > 1000) throw { message: "Can only return a maximum of 1000 pricebars" };


            var markets = CIAPI.dojo.clone(CIAPI.__testData.MarketList.slice(0, maxResults));
            for (var idx in markets) {
                markets[idx].Name = markets[idx].Name.replace("{marketName}", searchByMarketName);
            }
            return markets;
        },
        GetPriceBars: function(marketId, interval, span, priceBars) {
            var idx, marketPriceBars=[];

            if (interval !== 'minute') throw { message: "Only interval of 'minute' is currently supported" };
            if (priceBars > 1000) throw { message: "Can only return a maximum of 1000 pricebars" };

            for(idx in CIAPI.__testData.MarketList)
            {

                if (CIAPI.__testData.MarketList[idx].MarketId == marketId){
                    marketPriceBars = CIAPI.__testData.MarketList[idx].PriceHistory;
                    break;
                }
            }

            return {
                PartialPriceBar: CIAPI.dojo.clone(marketPriceBars.minute[0]),
                PriceBars: CIAPI.dojo.clone(marketPriceBars.minute.slice(1, priceBars + 1))
            };
        }
    };

})();var CIAPI = CIAPI || {};

CIAPI.streams = (function() {

    return {
        ListenToPrice: function(marketId, callBack) {
            setInterval(function() {
                var idx, change,
                    direction,
                    _priceBars;

                for(idx in CIAPI.__testData.MarketList)
                {
                    if (CIAPI.__testData.MarketList[idx].MarketId == marketId){
                        _priceBars = CIAPI.__testData.MarketList[idx].PriceHistory;
                        break;
                    }
                }
                direction = Math.random() > 0.5 ? 1 : -1;
                change = direction * _priceBars.minute[0].Close * 0.05;
                _priceBars.minute[0].Close += change;
                _priceBars.minute[0].High = (_priceBars.minute[0].Close > _priceBars.minute[0].High) ? _priceBars.minute[0].Close : _priceBars.minute[0].High;
                _priceBars.minute[0].Low = (_priceBars.minute[0].Close < _priceBars.minute[0].Low) ? _priceBars.minute[0].Close : _priceBars.minute[0].Low;
                callBack({
                    MarketId: marketId,
                    bid : _priceBars.minute[0].Close,
                    offer : _priceBars.minute[0].Close,
                    high : _priceBars.minute[0].High,
                    low : _priceBars.minute[0].Low,
                    change : change
                });
            }, Math.random() * 5000 + 1000);
        }
    };

})();/**
    @namespace DTOs relating to the API
*/
CIAPI.dtos = CIAPI.dtos || {};

/**
 * The details of a specific price bar, useful for plotting candlestick charts
 * @constructor
 *
 * @param barDate The date of the start of the price bar interval
 * @param open For the equities model of charting, this is the price at the start of the price bar interval.
 * @param high The highest price occurring during the interval of the price bar
 * @param low The lowest price occurring during the interval of the price bar
 * @param close The price at the end of the price bar interval
 *
 * @returns a frozen readonly object
 */
CIAPI.dtos.PriceBarDTO = function(barDate, open, high, low, high){
    /**
     * The date of the start of the price bar interval
     * @type Date
     */
    this.BarDate = barDate;

     /**
     * For the equities model of charting, this is the price at the start of the price bar interval.
     * @type Number
     */
    this.Open = open;

    /**
     * The highest price occurring during the interval of the price bar
     * @type Number
     */
    this.High = high;

    /**
     * The lowest price occurring during the interval of the price bar
     * @type Number
     */
    this.Low = low;

    /**
     * The price at the end of the price bar interval
     * @type Number
     */
    this.Close = close;



    Object.freeze(this);
}

