import { isPlainObject, isString, isNumber, assign } from 'lodash';
class ErrorWrapper extends Error {
  constructor(info, attached) {
    const attachedInfo = attached;
    const errorInfo = {
      errorCode: 0,
      message: 'unknow error',
      documentation_url: null
    };
    Object.defineProperty(errorInfo, 'errorMessage', {
      enumerable: true,
      get: () => {
        return this._error.errorCode;
      },
      set: () => {}
    });

    let paramInfo = null;
    if (isString(info)) {
      try {
        paramInfo = JSON.parse(info);
      } catch (err) {
        errorInfo.errorCode = 500;
      }
    } else if (isPlainObject(info)) {
      paramInfo = info;
    } else if (isNumber(info)) {
      errorInfo.errorCode = info;
    }

    paramInfo = paramInfo || {};
    assign(errorInfo, paramInfo);

    super({ value: errorInfo.message, configurable: true, writable: true });

    this._error = errorInfo;
    this._attached = attachedInfo;

    Object.defineProperty(this, 'Info', {
      enumerable: true,
      get: () => {
        return this._error;
      },
      set: () => {}
    });

    Object.defineProperty(this, 'Attached', {
      enumerable: true,
      get: () => {
        return this._attached;
      },
      set: () => {}
    });
  }
}

export default ErrorWrapper;
