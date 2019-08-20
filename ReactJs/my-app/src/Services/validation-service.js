// true : valid , false : invalid
const requiredValidator = (value) => {
    return value !== '';
}

const minLengthValidator = (value, minlength) => {
    return !(value.length < minlength);
}

const maxLengthValidator = (value, maxlength) => {
    return !(value.length > maxlength);
}

const patternValidator = (value, regex) => {
    return !regex.test(value);
}

const checkValidators = (value, err, errObj) => {
    switch (err) {
        case 'required':
            return requiredValidator(value);
        case 'minlength':
            return minLengthValidator(value, errObj.requiredLength);
        case 'maxlength':
            return maxLengthValidator(value, errObj.requiredLength);
        case 'pattern':
            return patternValidator(value, errObj)
    }
}

export const checkErrors = (value, validators) => {
    const errors = Object.keys(validators);
    let errorsOccured = [];
    for (let err of errors) {
        if (!checkValidators(value, err, validators[err])) {
            errorsOccured.push(getErrorMsg(err, validators[err]));
        }
    }
    return errorsOccured;
}

const errorMessages = {
    required: () => 'This field is required',
    pattern: () => 'Incorrect format',
    minlength: (param) => `Min chars required is ${param.requiredLength}`,
    maxlength: (param) => `Max chars allowed is ${param.requiredLength}`
};

const getErrorMsg = (err, errObj) => {
    return errorMessages[err](errObj);
}