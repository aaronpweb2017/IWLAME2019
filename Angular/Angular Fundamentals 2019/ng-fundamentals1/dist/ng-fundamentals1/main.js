(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _events_app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./events-app.component */ "./src/app/events-app.component.ts");
/* harmony import */ var _events_events_list_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./events/events-list.component */ "./src/app/events/events-list.component.ts");
/* harmony import */ var _events_event_thumbnail_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./events/event-thumbnail.component */ "./src/app/events/event-thumbnail.component.ts");
/* harmony import */ var _nav_navbar_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./nav/navbar.component */ "./src/app/nav/navbar.component.ts");
/* harmony import */ var _events_shared_event_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./events/shared/event.service */ "./src/app/events/shared/event.service.ts");
/* harmony import */ var _events_common_toastr_service__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./events/common/toastr.service */ "./src/app/events/common/toastr.service.ts");
/* harmony import */ var _events_event_details_event_details_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./events/event-details/event-details.component */ "./src/app/events/event-details/event-details.component.ts");
/* harmony import */ var _routes__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./routes */ "./src/app/routes.ts");
/* harmony import */ var _llll_directive__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./llll.directive */ "./src/app/llll.directive.ts");
/* harmony import */ var _yes_pipe__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./yes.pipe */ "./src/app/yes.pipe.ts");














var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__["BrowserModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(_routes__WEBPACK_IMPORTED_MODULE_11__["appRoutes"])
            ],
            declarations: [
                _events_app_component__WEBPACK_IMPORTED_MODULE_4__["EventsAppComponent"],
                _events_events_list_component__WEBPACK_IMPORTED_MODULE_5__["EventsListComponent"],
                _events_event_thumbnail_component__WEBPACK_IMPORTED_MODULE_6__["EventThumbnailComponent"],
                _events_event_details_event_details_component__WEBPACK_IMPORTED_MODULE_10__["EventDetailsComponent"],
                _nav_navbar_component__WEBPACK_IMPORTED_MODULE_7__["NavBarComponent"],
                _llll_directive__WEBPACK_IMPORTED_MODULE_12__["LlllDirective"],
                _yes_pipe__WEBPACK_IMPORTED_MODULE_13__["YesPipe"]
            ],
            providers: [_events_shared_event_service__WEBPACK_IMPORTED_MODULE_8__["EventService"], _events_common_toastr_service__WEBPACK_IMPORTED_MODULE_9__["ToastService"]],
            bootstrap: [_events_app_component__WEBPACK_IMPORTED_MODULE_4__["EventsAppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/events-app.component.html":
/*!*******************************************!*\
  !*** ./src/app/events-app.component.html ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<html>\n  <nav-bar></nav-bar>\n  <router-outlet></router-outlet>\n</html>"

/***/ }),

/***/ "./src/app/events-app.component.ts":
/*!*****************************************!*\
  !*** ./src/app/events-app.component.ts ***!
  \*****************************************/
/*! exports provided: EventsAppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EventsAppComponent", function() { return EventsAppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var EventsAppComponent = /** @class */ (function () {
    function EventsAppComponent() {
        this.title = 'ng-fundamentals1';
    }
    EventsAppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'events-app',
            template: __webpack_require__(/*! ./events-app.component.html */ "./src/app/events-app.component.html")
        })
    ], EventsAppComponent);
    return EventsAppComponent;
}());



/***/ }),

/***/ "./src/app/events/common/toastr.service.ts":
/*!*************************************************!*\
  !*** ./src/app/events/common/toastr.service.ts ***!
  \*************************************************/
/*! exports provided: ToastService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ToastService", function() { return ToastService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var ToastService = /** @class */ (function () {
    function ToastService() {
    }
    ToastService.prototype.success = function (message, title) {
        toastr.success(message, title);
    };
    ToastService.prototype.info = function (message, title) {
        toastr.info(message, title);
    };
    ToastService.prototype.warning = function (message, title) {
        toastr.warning(message, title);
    };
    ToastService.prototype.error = function (message, title) {
        toastr.error(message, title);
    };
    ToastService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])()
    ], ToastService);
    return ToastService;
}());



/***/ }),

/***/ "./src/app/events/event-details/event-details.component.html":
/*!*******************************************************************!*\
  !*** ./src/app/events/event-details/event-details.component.html ***!
  \*******************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"container\">\r\n    <img [src]=\"event?.imageUrl\" [alt]=\"event?.name\" class=\"event-image\">\r\n    <div class=\"row\">\r\n      <div class=\"col-md-11\">\r\n        <h2>{{event?.name}}</h2>\r\n      </div>\r\n    </div>\r\n  \r\n    <div class=\"row\">\r\n      <div class=\"col-md-6\">\r\n        <div><strong>Date:</strong>{{event?.date}}</div>\r\n        <div><strong>Time:</strong>{{event?.time}}</div>\r\n        <div><strong>Price:</strong>${{event?.price}}</div>\r\n      </div>\r\n      <div class=\"col-md-6\">\r\n        <address>\r\n          <strong>Address:</strong><br/>\r\n          {{event?.location?.address}}<br/>\r\n          {{event?.location?.city}},{{event?.location?.country}}\r\n        </address>\r\n      </div>\r\n    </div>\r\n  </div>"

/***/ }),

/***/ "./src/app/events/event-details/event-details.component.ts":
/*!*****************************************************************!*\
  !*** ./src/app/events/event-details/event-details.component.ts ***!
  \*****************************************************************/
/*! exports provided: EventDetailsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EventDetailsComponent", function() { return EventDetailsComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_event_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared/event.service */ "./src/app/events/shared/event.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");




var EventDetailsComponent = /** @class */ (function () {
    function EventDetailsComponent(eventService, route) {
        this.eventService = eventService;
        this.route = route;
    }
    EventDetailsComponent.prototype.ngOnInit = function () {
        this.event = this.eventService.getEvent(this.route.snapshot.params['id']);
    };
    EventDetailsComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            template: __webpack_require__(/*! ./event-details.component.html */ "./src/app/events/event-details/event-details.component.html"),
            styles: [".container {padding-left: 20px; padding-right: 20px;}\n     .event-image { height: 100px; } \n    "]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_shared_event_service__WEBPACK_IMPORTED_MODULE_2__["EventService"], _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"]])
    ], EventDetailsComponent);
    return EventDetailsComponent;
}());



/***/ }),

/***/ "./src/app/events/event-thumbnail.component.html":
/*!*******************************************************!*\
  !*** ./src/app/events/event-thumbnail.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<html>\r\n    <div [routerLink]=\"['/events',event.id]\" class=\"well hoverwell\" style=\"border-radius: 10px; margin-left: 20px;\">\r\n        <h2 style=\"font-weight: bold;\">event {{event?.id}}:</h2>\r\n        <span [hidden]=\"!event?.name\"><h4>Name: {{event?.name}}</h4></span>\r\n        <span><h4>Date: {{event?.date}}</h4></span>\r\n        <span><h4>Time: {{event?.time}}</h4></span>\r\n        <div [ngSwitch]=\"event?.time\">\r\n            <span [class.blue]=\"event?.time == '8:00 am'\" [class.normal]=\"event?.time == '8:00 am'\" *ngSwitchCase=\"'8:00 am'\"><h5>Early Start</h5></span>\r\n            <span [class.green]=\"event?.time == '9:00 am'\" [class.oblique]=\"event?.time == '9:00 am'\" *ngSwitchCase=\"'9:00 am'\"><h5>Medium Start 1</h5></span>\r\n            <span [class.yellow]=\"event?.time == '10:00 am'\" [class.italic]=\"event?.time == '10:00 am'\" *ngSwitchCase=\"'10:00 am'\"><h5>Medium Start 2</h5></span>\r\n            <span [class.red]=\"event?.time == '11:00 am'\" [class.bold]=\"event?.time == '11:00 am'\" *ngSwitchCase=\"'11:00 am'\"><h5>Late Start</h5></span>\r\n            <span *ngSwitchDefault><h5></h5>Normal Start</span>\r\n        </div>\r\n        <span *ngIf=\"event?.location?.address\"><h4 style=\"font-weight: bold;\">Location:</h4></span>\r\n        <div>\r\n            <span><h5 style=\"font-weight: bold;\">Address: {{event?.location?.address}} </h5></span>\r\n            <span><h5 style=\"font-weight: bold;\">City: {{event?.location?.city}} </h5></span>\r\n            <span><h5 style=\"font-weight: bold;\">Country: {{event?.location?.country}} </h5></span>\r\n        </div>\r\n        <span *ngIf=\"event?.sessions?.id\"><h4 style=\"font-weight: bold;\">Sessions:</h4></span>\r\n        \r\n        <ng-container *ngFor=\"let session of event?.sessions; let i = index\" [attr.data-index]=\"i\">\r\n            <div>\r\n                <span><h4 style=\"font-weight: bold;\">Session {{i+1}}: </h4></span>\r\n                <span style=\"display:inline-block; margin-left: 20px;\"><h5>Id: {{session.id}} </h5></span>\r\n                <span style=\"display:inline-block; margin-left: 20px;\"><h5>Name: {{session.name}} </h5></span>\r\n                <span style=\"display:inline-block; margin-left: 20px;\"><h5>Presenter: {{session.presenter}} </h5></span>\r\n                <span style=\"display:inline-block; margin-left: 20px;\"><h5>Duration: {{session.duration}} </h5></span>\r\n                <span style=\"display:inline-block; margin-left: 20px;\"><h5>Level: {{session.level}} </h5></span>\r\n                <span *ngIf=\"!session?.voters.length==0\"><h5 style=\"font-weight: bold;\">Voters:</h5></span>  \r\n                <ng-container *ngFor=\"let voter of session?.voters\">\r\n                    <span style=\"display:inline-block; margin-left: 20px;\"><h5>{{voter}}</h5></span>\r\n                </ng-container>\r\n            </div>\r\n        </ng-container>\r\n        <button style=\"margin-left: 5px;\" class=\"btn btn-primary\" (click)=\"showSessionsQuantity()\">Session_Quantity</button>\r\n        <button style=\"margin-left: 5px;\" class=\"btn btn-primary\" (click)=\"handleClickMe()\">Click_Here</button>\r\n    </div>\r\n</html>"

/***/ }),

/***/ "./src/app/events/event-thumbnail.component.ts":
/*!*****************************************************!*\
  !*** ./src/app/events/event-thumbnail.component.ts ***!
  \*****************************************************/
/*! exports provided: EventThumbnailComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EventThumbnailComponent", function() { return EventThumbnailComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var EventThumbnailComponent = /** @class */ (function () {
    function EventThumbnailComponent() {
        this.eventClick = new _angular_core__WEBPACK_IMPORTED_MODULE_1__["EventEmitter"]();
    }
    EventThumbnailComponent.prototype.handleClickMe = function () {
        alert('Some event clicked...');
        console.log('Some event clicked...');
        this.eventClick.emit(this.event.id);
    };
    EventThumbnailComponent.prototype.showSessionsQuantity = function () {
        alert('CurrentSessionsQuantity: ' + this.event.sessions.length);
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object)
    ], EventThumbnailComponent.prototype, "event", void 0);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Input"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object)
    ], EventThumbnailComponent.prototype, "eventsQuantity", void 0);
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Output"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", Object)
    ], EventThumbnailComponent.prototype, "eventClick", void 0);
    EventThumbnailComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'event-thumbnail',
            template: __webpack_require__(/*! ./event-thumbnail.component.html */ "./src/app/events/event-thumbnail.component.html"),
            styles: [".red { color: #FF0000 !important; }\n        .green { color: #00FF00 !important; }\n        .blue { color: #0000FF !important; }\n        .yellow { color: #FFFF00 !important; }\n        .bold { font-weight: bold; }\n        .oblique { font-style: oblique; }\n        .italic { font-style: italic; }\n        .normal { font-style: normal; }\n        .thumbnail { min-height: 210px; }\n        .pad-left { margin-left: 10px; }\n        .well_div { color: #bbb; }"]
        })
    ], EventThumbnailComponent);
    return EventThumbnailComponent;
}());



/***/ }),

/***/ "./src/app/events/events-list.component.html":
/*!***************************************************!*\
  !*** ./src/app/events/events-list.component.html ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<html>\r\n    <h1 style=\"font-style: oblique; font-weight: bold;\">New Events List (Registration):</h1>\r\n    <div style=\"display: flex;\">\r\n        <ng-container *ngFor=\"let event of events\">\r\n            <event-thumbnail (click)=\"handleThumbnailClick(event.name)\" [event]=\"event\"\r\n            (eventClick)=\"handleEventClicked($event)\"></event-thumbnail>\r\n        </ng-container>\r\n    </div>\r\n</html>"

/***/ }),

/***/ "./src/app/events/events-list.component.ts":
/*!*************************************************!*\
  !*** ./src/app/events/events-list.component.ts ***!
  \*************************************************/
/*! exports provided: EventsListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EventsListComponent", function() { return EventsListComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_event_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./shared/event.service */ "./src/app/events/shared/event.service.ts");
/* harmony import */ var _common_toastr_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./common/toastr.service */ "./src/app/events/common/toastr.service.ts");




var EventsListComponent = /** @class */ (function () {
    function EventsListComponent(eventService, toastr) {
        this.eventService = eventService;
        this.toastr = toastr;
    }
    EventsListComponent.prototype.handleEventClicked = function (id) {
        alert('Clicked Event Id: ' + id);
        console.log('Clicked Event Id: ' + id);
    };
    EventsListComponent.prototype.ngOnInit = function () {
        this.events = this.eventService.getEvents();
    };
    EventsListComponent.prototype.handleThumbnailClick = function (eventName) {
        this.toastr.success("Click on: " + eventName + "event.");
    };
    EventsListComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            template: __webpack_require__(/*! ./events-list.component.html */ "./src/app/events/events-list.component.html"),
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_shared_event_service__WEBPACK_IMPORTED_MODULE_2__["EventService"], _common_toastr_service__WEBPACK_IMPORTED_MODULE_3__["ToastService"]])
    ], EventsListComponent);
    return EventsListComponent;
}());



/***/ }),

/***/ "./src/app/events/shared/event.service.ts":
/*!************************************************!*\
  !*** ./src/app/events/shared/event.service.ts ***!
  \************************************************/
/*! exports provided: EventService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EventService", function() { return EventService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var EventService = /** @class */ (function () {
    function EventService() {
    }
    EventService.prototype.getEvents = function () {
        return events;
    };
    EventService.prototype.getEvent = function (id) {
        return events.find(function (event) { return event.id == id; });
    };
    EventService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])()
    ], EventService);
    return EventService;
}());

var events = [
    {
        id: 1,
        name: 'Angular Connect',
        date: '9/26/2036',
        time: '8:00 am',
        price: 599.99,
        imageUrl: '/assets/images/angularconnect-shield.png',
        location: {
            address: '1057 DT',
            city: 'London',
            country: 'England'
        },
        sessions: [
            {
                id: 1,
                name: "Using Angular 4 Pipes",
                presenter: "Peter Bacon Darwin",
                duration: 1,
                level: "Intermediate",
                abstract: "Learn all about the new pipes in Angular 4, both \n          how to write them, and how to get the new AI CLI to write \n          them for you. Given by the famous PBD, president of Angular \n          University (formerly Oxford University)",
                voters: ['bradgreen', 'igorminar', 'martinfowler']
            },
            {
                id: 2,
                name: "Getting the most out of your dev team",
                presenter: "Jeff Cross",
                duration: 1,
                level: "Intermediate",
                abstract: "We all know that our dev teams work hard, but with \n          the right management they can be even more productive, without \n          overworking them. In this session I'll show you how to get the \n          best results from the talent you already have on staff.",
                voters: ['johnpapa', 'bradgreen', 'igorminar', 'martinfowler']
            },
            {
                id: 3,
                name: "Angular 4 Performance Metrics",
                presenter: "Rob Wormald",
                duration: 2,
                level: "Advanced",
                abstract: "Angular 4 Performance is hot. In this session, we'll see \n          how Angular gets such great performance by preloading data on \n          your users devices before they even hit your site using the \n          new predictive algorithms and thought reading software \n          built into Angular 4.",
                voters: []
            },
            {
                id: 4,
                name: "Angular 5 Look Ahead",
                presenter: "Brad Green",
                duration: 2,
                level: "Advanced",
                abstract: "Even though Angular 5 is still 6 years away, we all want \n          to know all about it so that we can spend endless hours in meetings \n          debating if we should use Angular 4 or not. This talk will look at \n          Angular 6 even though no code has yet been written for it. We'll \n          look at what it might do, and how to convince your manager to \n          hold off on any new apps until it's released",
                voters: []
            },
            {
                id: 5,
                name: "Basics of Angular 4",
                presenter: "John Papa",
                duration: 2,
                level: "Beginner",
                abstract: "It's time to learn the basics of Angular 4. This talk \n          will give you everything you need to know about Angular 4 to \n          get started with it today and be building UI's for your self \n          driving cars and butler-bots in no time.",
                voters: ['bradgreen', 'igorminar']
            }
        ]
    },
    {
        id: 2,
        name: 'ng-nl',
        date: '4/15/2037',
        time: '9:00 am',
        price: 950.00,
        imageUrl: '/assets/images/basic-shield.png',
        location: {
            address: 'The NG-NL Convention Center & Scuba Shop',
            city: 'Amsterdam',
            country: 'Netherlands'
        },
        sessions: [
            {
                id: 1,
                name: "Testing Angular 4 Workshop",
                presenter: "Pascal Precht & Christoph Bergdorf",
                duration: 4,
                level: "Beginner",
                abstract: "In this 6 hour workshop you will learn not only how to test Angular 4, \n          you will also learn how to make the most of your team's efforts. Other topics\n          will be convincing your manager that testing is a good idea, and using the new\n          protractor tool for end to end testing.",
                voters: ['bradgreen', 'igorminar']
            },
            {
                id: 2,
                name: "Angular 4 and Firebase",
                presenter: "David East",
                duration: 3,
                level: "Intermediate",
                abstract: "In this workshop, David East will show you how to use Angular with the new\n          ultra-real-time 5D Firebase back end, hosting platform, and wine recommendation engine.",
                voters: ['bradgreen', 'igorminar', 'johnpapa']
            },
            {
                id: 3,
                name: "Reading the Angular 4 Source",
                presenter: "Patrick Stapleton",
                duration: 2,
                level: "Intermediate",
                abstract: "Angular 4's source code may be over 25 million lines of code, but it's really \n          a lot easier to read and understand then you may think. Patrick Stapleton will talk\n          about his secretes for keeping up with the changes, and navigating around the code.",
                voters: ['martinfowler']
            },
            {
                id: 4,
                name: "Hail to the Lukas",
                presenter: "Lukas Ruebbelke",
                duration: 1,
                level: "Beginner",
                abstract: "In this session, Lukas will present the \n          secret to being awesome, and how he became the President \n          of the United States through his amazing programming skills, \n          showing how you too can be success with just attitude.",
                voters: ['bradgreen']
            },
        ]
    },
    {
        id: 3,
        name: 'ng-conf 2037',
        date: '5/4/2037',
        time: '10:00 am',
        price: 759.00,
        imageUrl: '/assets/images/ng-conf.png',
        location: {
            address: 'The Palatial America Hotel',
            city: 'Salt Lake City',
            country: 'USA'
        },
        sessions: [
            {
                id: 1,
                name: "How Elm Powers Angular 4",
                presenter: "Murphy Randle",
                duration: 2,
                level: "Intermediate",
                abstract: "We all know that Angular is written in Elm, but did you\n          know how the source code is really written? In this exciting look\n          into the internals of Angular 4, we'll see exactly how Elm powers\n          the framework, and what you can do to take advantage of this knowledge.",
                voters: ['bradgreen', 'martinfowler', 'igorminar']
            },
            {
                id: 2,
                name: "Angular and React together",
                presenter: "Jamison Dance",
                duration: 2,
                level: "Intermediate",
                abstract: "React v449.6 has just been released. Let's see how to use \n          this new version with Angular to create even more impressive applications.",
                voters: ['bradgreen', 'martinfowler']
            },
            {
                id: 3,
                name: "Redux Woes",
                presenter: "Rob Wormald",
                duration: 1,
                level: "Intermediate",
                abstract: "Everyone is using Redux for everything from Angular to React to \n          Excel macros, but you're still having trouble grasping it? We'll take a look\n          at how farmers use Redux when harvesting grain as a great introduction to \n          this game changing technology.",
                voters: ['bradgreen', 'martinfowler', 'johnpapa']
            },
            {
                id: 4,
                name: "ng-wat again!!",
                presenter: "Shai Reznik",
                duration: 1,
                level: "Beginner",
                abstract: "Let's take a look at some of the stranger pieces of Angular 4,\n          including neural net nets, Android in Androids, and using pipes with actual pipes.",
                voters: ['bradgreen', 'martinfowler', 'igorminar', 'johnpapa']
            },
            {
                id: 5,
                name: "Dressed for Success",
                presenter: "Ward Bell",
                duration: 2,
                level: "Beginner",
                abstract: "Being a developer in 2037 is about more than just writing bug-free code. \n          You also have to look the part. In this amazing expose, Ward will talk you through\n          how to pick out the right clothes to make your coworkers and boss not only\n          respect you, but also want to be your buddy.",
                voters: ['bradgreen', 'martinfowler']
            },
            {
                id: 6,
                name: "These aren't the directives you're looking for",
                presenter: "John Papa",
                duration: 2,
                level: "Intermediate",
                abstract: "Coinciding with the release of Star Wars Episode 18, this talk will show how\n          to use directives in your Angular 4 development while drawing lessons from the new movie,\n          featuring all your favorite characters like Han Solo's ghost and Darth Jar Jar.",
                voters: ['bradgreen', 'martinfowler']
            },
        ]
    },
    {
        id: 4,
        name: 'UN Angular Summit',
        date: '6/10/2037',
        time: '11:00 am',
        price: 800.00,
        imageUrl: '/assets/images/ng-nl.png',
        location: {
            address: 'The UN Angular Center',
            city: 'New York',
            country: 'USA'
        },
        sessions: [
            {
                id: 1,
                name: "Diversity in Tech",
                presenter: "Sir Dave Smith",
                duration: 2,
                level: "Beginner",
                abstract: "Yes, we all work with cyborgs and androids and Martians, but \n          we probably don't realize that sometimes our internal biases can make it difficult for\n          these well-designed coworkers to really feel at home coding alongside us. This talk will\n          look at things we can do to recognize our biases and counteract them.",
                voters: ['bradgreen', 'igorminar']
            },
            {
                id: 2,
                name: "World Peace and Angular",
                presenter: "US Secretary of State Zach Galifianakis",
                duration: 2,
                level: "Beginner",
                abstract: "Angular has been used in most of the major peace brokering that has\n          happened in the last decade, but there is still much we can do to remove all\n          war from the world, and Angular will be a key part of that effort.",
                voters: ['bradgreen', 'igorminar', 'johnpapa']
            },
            {
                id: 3,
                name: "Using Angular with Androids",
                presenter: "Dan Wahlin",
                duration: 3,
                level: "Advanced",
                abstract: "Androids may do everything for us now, allowing us to spend all day playing \n          the latest Destiny DLC, but we can still improve the massages they give and the handmade\n          brie they make using Angular 4. This session will show you how.",
                voters: ['igorminar', 'johnpapa']
            },
        ]
    }
];


/***/ }),

/***/ "./src/app/llll.directive.ts":
/*!***********************************!*\
  !*** ./src/app/llll.directive.ts ***!
  \***********************************/
/*! exports provided: LlllDirective */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LlllDirective", function() { return LlllDirective; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var LlllDirective = /** @class */ (function () {
    function LlllDirective() {
    }
    LlllDirective = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Directive"])({
            selector: '[appLlll]'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], LlllDirective);
    return LlllDirective;
}());



/***/ }),

/***/ "./src/app/nav/nav-bar.component.html":
/*!********************************************!*\
  !*** ./src/app/nav/nav-bar.component.html ***!
  \********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"navbar navbar-default\">\r\n    <div class=\"container-fluid\">\r\n      <div class=\"navbar-header\">\r\n        <a class=\"navbar-brand\" >ngEvents</a>\r\n      </div>\r\n  \r\n      <div class=\"collapse navbar-collapse\">\r\n        <ul class=\"nav navbar-nav\">\r\n          <li>\r\n            <a [routerLink]=\"['/events']\">All Events</a>\r\n          </li>\r\n          <li><a href=\"\">Create Event</a></li>\r\n          <li class=\"dropdown\">\r\n            <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" >\r\n              Events\r\n              <span class=\"caret\"></span>\r\n            </a>\r\n            <ul class=\"dropdown-menu\">\r\n              <li >\r\n                <a href=\"\">Angular Connect</a>\r\n              </li>\r\n            </ul>\r\n          </li>\r\n        </ul>\r\n        <div class=\"navbar-header navbar-right\">\r\n          <ul class=\"nav navbar-nav\">\r\n            <li>\r\n              <a>Welcome John</a>\r\n            </li>\r\n          </ul>\r\n        </div>\r\n        <form id=\"searchForm\"  class=\"navbar-form navbar-right\"  >\r\n          <div class=\"form-group\">\r\n            <input type=\"text\" class=\"form-control\" placeholder=\"Search Sessions\" >\r\n          </div>\r\n          <button class=\"btn btn-default\" >\r\n            Search\r\n          </button>\r\n        </form>\r\n      </div>\r\n    </div>\r\n  </div>"

/***/ }),

/***/ "./src/app/nav/navbar.component.ts":
/*!*****************************************!*\
  !*** ./src/app/nav/navbar.component.ts ***!
  \*****************************************/
/*! exports provided: NavBarComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavBarComponent", function() { return NavBarComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var NavBarComponent = /** @class */ (function () {
    function NavBarComponent() {
    }
    NavBarComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'nav-bar',
            template: __webpack_require__(/*! ./nav-bar.component.html */ "./src/app/nav/nav-bar.component.html")
        })
    ], NavBarComponent);
    return NavBarComponent;
}());



/***/ }),

/***/ "./src/app/routes.ts":
/*!***************************!*\
  !*** ./src/app/routes.ts ***!
  \***************************/
/*! exports provided: appRoutes */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "appRoutes", function() { return appRoutes; });
/* harmony import */ var _events_events_list_component__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./events/events-list.component */ "./src/app/events/events-list.component.ts");
/* harmony import */ var _events_event_details_event_details_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./events/event-details/event-details.component */ "./src/app/events/event-details/event-details.component.ts");


var appRoutes = [
    { path: 'events', component: _events_events_list_component__WEBPACK_IMPORTED_MODULE_0__["EventsListComponent"] },
    { path: 'events/:id', component: _events_event_details_event_details_component__WEBPACK_IMPORTED_MODULE_1__["EventDetailsComponent"] },
    { path: '', redirectTo: '/events', pathMatch: 'full' }
];


/***/ }),

/***/ "./src/app/yes.pipe.ts":
/*!*****************************!*\
  !*** ./src/app/yes.pipe.ts ***!
  \*****************************/
/*! exports provided: YesPipe */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "YesPipe", function() { return YesPipe; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var YesPipe = /** @class */ (function () {
    function YesPipe() {
    }
    YesPipe.prototype.transform = function (value, args) {
        return null;
    };
    YesPipe = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Pipe"])({
            name: 'yes'
        })
    ], YesPipe);
    return YesPipe;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\e-lmedina\Documents\RepositoriosGitHub\IWLAME2019\Angular\Angular Fundamentals 2019\ng-fundamentals1\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map