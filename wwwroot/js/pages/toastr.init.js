$("#basic-form")
  .parsley()
  .on("form:error", function () {
    // In here, `this` is the parlsey instance of #some-input
    $.toast({
      heading: "发生了一些错误？",
      text: "请仔细检查您的表单项目是否有不合格式的内容，修改后再次尝试",
      position: "top-right",
      loaderBg: "#bf441d",
      icon: "error",
      hideAfter: 4e3,
      stack: 1,
    });
    console.log(this.$element);
  });