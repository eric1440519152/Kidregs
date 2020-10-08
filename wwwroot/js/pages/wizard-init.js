!(function (e) {
  "use strict";
  var t = function () {};
  (t.prototype.createBasic = function (t) {
    return (
      t.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        onStepChanging: function (event, currentIndex, newIndex) {
          /*步骤更改之前进行验证，默认验证结果是true*/
          return true;
          //$("#basic-form").parsley().validate(); /*验证结果*/
        },
        onFinishing: function (t, i) {
          return console.log("Form has been validated!"), !0;
        },
        onFinished: function (t, i) {
          console.log(
            "Form can be submitted using submit method. E.g. $('#basic-form').submit()"
          ),
            e("#basic-form").submit();
        },
        labels: {
          cancel: "取消",
          current: "当前您在:",
          pagination: "页码",
          finish: "提交",
          next: "下一步",
          previous: "上一步",
          loading: "加载中 ...",
        },
      }),
      t
    );
  }),
    (t.prototype.createVertical = function (t) {
      return (
        t.steps({
          headerTag: "h3",
          bodyTag: "section",
          transitionEffect: "fade",
          stepsOrientation: "vertical",
        }),
        t
      );
    }),
    (t.prototype.init = function () {
      this.createBasic(e("#basic-form")),
        this.createVertical(e("#wizard-vertical"));
    }),
    (e.FormWizard = new t()),
    (e.FormWizard.Constructor = t);
})(window.jQuery),
  (function (t) {
    "use strict";
    window.jQuery.FormWizard.init();
  })();
