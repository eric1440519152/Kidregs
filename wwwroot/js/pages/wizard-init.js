!(function (e) {
    "use strict";
    var back = false;
    var t = function () { };
    (t.prototype.createBasic = function (t) {
        return (
            t.children("div").steps({
                headerTag: "h3",
                bodyTag: "section",
                transitionEffect: "slideLeft",
                onStepChanging: function(event, currentIndex, newIndex) {
                    console.log(currentIndex,newIndex);
                    /*步骤更改之前进行验证，默认验证结果是true*/
                    if (newIndex < currentIndex)
                        return true;

                    if (back) {
                        back = false;
                        return true;
                    } else
                    if (currentIndex == 0) {
                        $("#basic-form").parsley().whenValidate({
                            group: "section-0"
                        }).then(
                            function (res) {
                                console.log("成功", res);
                                back = true;
                                t.children("div").steps("next");
                            },
                            function (err) {
                                console.log("失败", err);
                                back = false;
                            }
                        );
                        return false;
                    } else {
                        return $("#basic-form").parsley().validate("section-" + currentIndex);
                    }

                },
                onFinishing: function (t, i) {
                    var valid = $("#basic-form").parsley().validate("section-3");
                    if (valid) {
                        console.log("表单通过验证，数据开始提交");
                        $("[href='#finish']").attr("hidden", "hidden");
                    }
                    return valid;
                },
                onFinished: function (t, i) {
                    $("[href='#finish']").attr("hidden", "hidden");
                    $("#basic-form").submit();
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