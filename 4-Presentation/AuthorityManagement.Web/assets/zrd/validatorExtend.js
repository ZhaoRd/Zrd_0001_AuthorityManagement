jQuery.validator.addMethod(
    "ismobile",
    function (value, element) {
        var length = value.length;
        return this.optional(element)
            || length === 11 && /^1[3578]\d{9}$/.test(value);
    },
    "请填写正确的手机号码");