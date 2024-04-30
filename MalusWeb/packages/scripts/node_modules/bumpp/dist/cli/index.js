var __create = Object.create;
var __defProp = Object.defineProperty;
var __defProps = Object.defineProperties;
var __getOwnPropDesc = Object.getOwnPropertyDescriptor;
var __getOwnPropDescs = Object.getOwnPropertyDescriptors;
var __getOwnPropNames = Object.getOwnPropertyNames;
var __getOwnPropSymbols = Object.getOwnPropertySymbols;
var __getProtoOf = Object.getPrototypeOf;
var __hasOwnProp = Object.prototype.hasOwnProperty;
var __propIsEnum = Object.prototype.propertyIsEnumerable;
var __defNormalProp = (obj, key, value) => key in obj ? __defProp(obj, key, { enumerable: true, configurable: true, writable: true, value }) : obj[key] = value;
var __spreadValues = (a, b) => {
  for (var prop in b || (b = {}))
    if (__hasOwnProp.call(b, prop))
      __defNormalProp(a, prop, b[prop]);
  if (__getOwnPropSymbols)
    for (var prop of __getOwnPropSymbols(b)) {
      if (__propIsEnum.call(b, prop))
        __defNormalProp(a, prop, b[prop]);
    }
  return a;
};
var __spreadProps = (a, b) => __defProps(a, __getOwnPropDescs(b));
var __objRest = (source, exclude) => {
  var target = {};
  for (var prop in source)
    if (__hasOwnProp.call(source, prop) && exclude.indexOf(prop) < 0)
      target[prop] = source[prop];
  if (source != null && __getOwnPropSymbols)
    for (var prop of __getOwnPropSymbols(source)) {
      if (exclude.indexOf(prop) < 0 && __propIsEnum.call(source, prop))
        target[prop] = source[prop];
    }
  return target;
};
var __commonJS = (cb, mod) => function __require() {
  return mod || (0, cb[__getOwnPropNames(cb)[0]])((mod = { exports: {} }).exports, mod), mod.exports;
};
var __export = (target, all) => {
  for (var name in all)
    __defProp(target, name, { get: all[name], enumerable: true });
};
var __copyProps = (to, from, except, desc) => {
  if (from && typeof from === "object" || typeof from === "function") {
    for (let key of __getOwnPropNames(from))
      if (!__hasOwnProp.call(to, key) && key !== except)
        __defProp(to, key, { get: () => from[key], enumerable: !(desc = __getOwnPropDesc(from, key)) || desc.enumerable });
  }
  return to;
};
var __toESM = (mod, isNodeMode, target) => (target = mod != null ? __create(__getProtoOf(mod)) : {}, __copyProps(
  // If the importer is in node compatibility mode or this is not an ESM
  // file that has been converted to a CommonJS file using a Babel-
  // compatible transform (i.e. "__esModule" has not been set), then set
  // "default" to the CommonJS "module.exports" for node compatibility.
  isNodeMode || !mod || !mod.__esModule ? __defProp(target, "default", { value: mod, enumerable: true }) : target,
  mod
));
var __toCommonJS = (mod) => __copyProps(__defProp({}, "__esModule", { value: true }), mod);

// node_modules/.pnpm/picocolors@1.0.0/node_modules/picocolors/picocolors.js
var require_picocolors = __commonJS({
  "node_modules/.pnpm/picocolors@1.0.0/node_modules/picocolors/picocolors.js"(exports2, module2) {
    var tty2 = require("tty");
    var isColorSupported = !("NO_COLOR" in process.env || process.argv.includes("--no-color")) && ("FORCE_COLOR" in process.env || process.argv.includes("--color") || process.platform === "win32" || tty2.isatty(1) && process.env.TERM !== "dumb" || "CI" in process.env);
    var formatter = (open, close, replace = open) => (input) => {
      let string = "" + input;
      let index = string.indexOf(close, open.length);
      return ~index ? open + replaceClose(string, close, replace, index) + close : open + string + close;
    };
    var replaceClose = (string, close, replace, index) => {
      let start = string.substring(0, index) + replace;
      let end = string.substring(index + close.length);
      let nextIndex = end.indexOf(close);
      return ~nextIndex ? start + replaceClose(end, close, replace, nextIndex) : start + end;
    };
    var createColors = (enabled = isColorSupported) => ({
      isColorSupported: enabled,
      reset: enabled ? (s) => `\x1B[0m${s}\x1B[0m` : String,
      bold: enabled ? formatter("\x1B[1m", "\x1B[22m", "\x1B[22m\x1B[1m") : String,
      dim: enabled ? formatter("\x1B[2m", "\x1B[22m", "\x1B[22m\x1B[2m") : String,
      italic: enabled ? formatter("\x1B[3m", "\x1B[23m") : String,
      underline: enabled ? formatter("\x1B[4m", "\x1B[24m") : String,
      inverse: enabled ? formatter("\x1B[7m", "\x1B[27m") : String,
      hidden: enabled ? formatter("\x1B[8m", "\x1B[28m") : String,
      strikethrough: enabled ? formatter("\x1B[9m", "\x1B[29m") : String,
      black: enabled ? formatter("\x1B[30m", "\x1B[39m") : String,
      red: enabled ? formatter("\x1B[31m", "\x1B[39m") : String,
      green: enabled ? formatter("\x1B[32m", "\x1B[39m") : String,
      yellow: enabled ? formatter("\x1B[33m", "\x1B[39m") : String,
      blue: enabled ? formatter("\x1B[34m", "\x1B[39m") : String,
      magenta: enabled ? formatter("\x1B[35m", "\x1B[39m") : String,
      cyan: enabled ? formatter("\x1B[36m", "\x1B[39m") : String,
      white: enabled ? formatter("\x1B[37m", "\x1B[39m") : String,
      gray: enabled ? formatter("\x1B[90m", "\x1B[39m") : String,
      bgBlack: enabled ? formatter("\x1B[40m", "\x1B[49m") : String,
      bgRed: enabled ? formatter("\x1B[41m", "\x1B[49m") : String,
      bgGreen: enabled ? formatter("\x1B[42m", "\x1B[49m") : String,
      bgYellow: enabled ? formatter("\x1B[43m", "\x1B[49m") : String,
      bgBlue: enabled ? formatter("\x1B[44m", "\x1B[49m") : String,
      bgMagenta: enabled ? formatter("\x1B[45m", "\x1B[49m") : String,
      bgCyan: enabled ? formatter("\x1B[46m", "\x1B[49m") : String,
      bgWhite: enabled ? formatter("\x1B[47m", "\x1B[49m") : String
    });
    module2.exports = createColors();
    module2.exports.createColors = createColors;
  }
});

// src/cli/index.ts
var cli_exports = {};
__export(cli_exports, {
  main: () => main2
});
module.exports = __toCommonJS(cli_exports);
var import_node_process8 = __toESM(require("process"));

// node_modules/.pnpm/chalk@5.3.0/node_modules/chalk/source/vendor/ansi-styles/index.js
var ANSI_BACKGROUND_OFFSET = 10;
var wrapAnsi16 = (offset = 0) => (code) => `\x1B[${code + offset}m`;
var wrapAnsi256 = (offset = 0) => (code) => `\x1B[${38 + offset};5;${code}m`;
var wrapAnsi16m = (offset = 0) => (red, green, blue) => `\x1B[${38 + offset};2;${red};${green};${blue}m`;
var styles = {
  modifier: {
    reset: [0, 0],
    // 21 isn't widely supported and 22 does the same thing
    bold: [1, 22],
    dim: [2, 22],
    italic: [3, 23],
    underline: [4, 24],
    overline: [53, 55],
    inverse: [7, 27],
    hidden: [8, 28],
    strikethrough: [9, 29]
  },
  color: {
    black: [30, 39],
    red: [31, 39],
    green: [32, 39],
    yellow: [33, 39],
    blue: [34, 39],
    magenta: [35, 39],
    cyan: [36, 39],
    white: [37, 39],
    // Bright color
    blackBright: [90, 39],
    gray: [90, 39],
    // Alias of `blackBright`
    grey: [90, 39],
    // Alias of `blackBright`
    redBright: [91, 39],
    greenBright: [92, 39],
    yellowBright: [93, 39],
    blueBright: [94, 39],
    magentaBright: [95, 39],
    cyanBright: [96, 39],
    whiteBright: [97, 39]
  },
  bgColor: {
    bgBlack: [40, 49],
    bgRed: [41, 49],
    bgGreen: [42, 49],
    bgYellow: [43, 49],
    bgBlue: [44, 49],
    bgMagenta: [45, 49],
    bgCyan: [46, 49],
    bgWhite: [47, 49],
    // Bright color
    bgBlackBright: [100, 49],
    bgGray: [100, 49],
    // Alias of `bgBlackBright`
    bgGrey: [100, 49],
    // Alias of `bgBlackBright`
    bgRedBright: [101, 49],
    bgGreenBright: [102, 49],
    bgYellowBright: [103, 49],
    bgBlueBright: [104, 49],
    bgMagentaBright: [105, 49],
    bgCyanBright: [106, 49],
    bgWhiteBright: [107, 49]
  }
};
var modifierNames = Object.keys(styles.modifier);
var foregroundColorNames = Object.keys(styles.color);
var backgroundColorNames = Object.keys(styles.bgColor);
var colorNames = [...foregroundColorNames, ...backgroundColorNames];
function assembleStyles() {
  const codes = /* @__PURE__ */ new Map();
  for (const [groupName, group] of Object.entries(styles)) {
    for (const [styleName, style] of Object.entries(group)) {
      styles[styleName] = {
        open: `\x1B[${style[0]}m`,
        close: `\x1B[${style[1]}m`
      };
      group[styleName] = styles[styleName];
      codes.set(style[0], style[1]);
    }
    Object.defineProperty(styles, groupName, {
      value: group,
      enumerable: false
    });
  }
  Object.defineProperty(styles, "codes", {
    value: codes,
    enumerable: false
  });
  styles.color.close = "\x1B[39m";
  styles.bgColor.close = "\x1B[49m";
  styles.color.ansi = wrapAnsi16();
  styles.color.ansi256 = wrapAnsi256();
  styles.color.ansi16m = wrapAnsi16m();
  styles.bgColor.ansi = wrapAnsi16(ANSI_BACKGROUND_OFFSET);
  styles.bgColor.ansi256 = wrapAnsi256(ANSI_BACKGROUND_OFFSET);
  styles.bgColor.ansi16m = wrapAnsi16m(ANSI_BACKGROUND_OFFSET);
  Object.defineProperties(styles, {
    rgbToAnsi256: {
      value(red, green, blue) {
        if (red === green && green === blue) {
          if (red < 8) {
            return 16;
          }
          if (red > 248) {
            return 231;
          }
          return Math.round((red - 8) / 247 * 24) + 232;
        }
        return 16 + 36 * Math.round(red / 255 * 5) + 6 * Math.round(green / 255 * 5) + Math.round(blue / 255 * 5);
      },
      enumerable: false
    },
    hexToRgb: {
      value(hex) {
        const matches = /[a-f\d]{6}|[a-f\d]{3}/i.exec(hex.toString(16));
        if (!matches) {
          return [0, 0, 0];
        }
        let [colorString] = matches;
        if (colorString.length === 3) {
          colorString = [...colorString].map((character) => character + character).join("");
        }
        const integer = Number.parseInt(colorString, 16);
        return [
          /* eslint-disable no-bitwise */
          integer >> 16 & 255,
          integer >> 8 & 255,
          integer & 255
          /* eslint-enable no-bitwise */
        ];
      },
      enumerable: false
    },
    hexToAnsi256: {
      value: (hex) => styles.rgbToAnsi256(...styles.hexToRgb(hex)),
      enumerable: false
    },
    ansi256ToAnsi: {
      value(code) {
        if (code < 8) {
          return 30 + code;
        }
        if (code < 16) {
          return 90 + (code - 8);
        }
        let red;
        let green;
        let blue;
        if (code >= 232) {
          red = ((code - 232) * 10 + 8) / 255;
          green = red;
          blue = red;
        } else {
          code -= 16;
          const remainder = code % 36;
          red = Math.floor(code / 36) / 5;
          green = Math.floor(remainder / 6) / 5;
          blue = remainder % 6 / 5;
        }
        const value = Math.max(red, green, blue) * 2;
        if (value === 0) {
          return 30;
        }
        let result = 30 + (Math.round(blue) << 2 | Math.round(green) << 1 | Math.round(red));
        if (value === 2) {
          result += 60;
        }
        return result;
      },
      enumerable: false
    },
    rgbToAnsi: {
      value: (red, green, blue) => styles.ansi256ToAnsi(styles.rgbToAnsi256(red, green, blue)),
      enumerable: false
    },
    hexToAnsi: {
      value: (hex) => styles.ansi256ToAnsi(styles.hexToAnsi256(hex)),
      enumerable: false
    }
  });
  return styles;
}
var ansiStyles = assembleStyles();
var ansi_styles_default = ansiStyles;

// node_modules/.pnpm/chalk@5.3.0/node_modules/chalk/source/vendor/supports-color/index.js
var import_node_process = __toESM(require("process"), 1);
var import_node_os = __toESM(require("os"), 1);
var import_node_tty = __toESM(require("tty"), 1);
function hasFlag(flag, argv = globalThis.Deno ? globalThis.Deno.args : import_node_process.default.argv) {
  const prefix = flag.startsWith("-") ? "" : flag.length === 1 ? "-" : "--";
  const position = argv.indexOf(prefix + flag);
  const terminatorPosition = argv.indexOf("--");
  return position !== -1 && (terminatorPosition === -1 || position < terminatorPosition);
}
var { env } = import_node_process.default;
var flagForceColor;
if (hasFlag("no-color") || hasFlag("no-colors") || hasFlag("color=false") || hasFlag("color=never")) {
  flagForceColor = 0;
} else if (hasFlag("color") || hasFlag("colors") || hasFlag("color=true") || hasFlag("color=always")) {
  flagForceColor = 1;
}
function envForceColor() {
  if ("FORCE_COLOR" in env) {
    if (env.FORCE_COLOR === "true") {
      return 1;
    }
    if (env.FORCE_COLOR === "false") {
      return 0;
    }
    return env.FORCE_COLOR.length === 0 ? 1 : Math.min(Number.parseInt(env.FORCE_COLOR, 10), 3);
  }
}
function translateLevel(level) {
  if (level === 0) {
    return false;
  }
  return {
    level,
    hasBasic: true,
    has256: level >= 2,
    has16m: level >= 3
  };
}
function _supportsColor(haveStream, { streamIsTTY, sniffFlags = true } = {}) {
  const noFlagForceColor = envForceColor();
  if (noFlagForceColor !== void 0) {
    flagForceColor = noFlagForceColor;
  }
  const forceColor = sniffFlags ? flagForceColor : noFlagForceColor;
  if (forceColor === 0) {
    return 0;
  }
  if (sniffFlags) {
    if (hasFlag("color=16m") || hasFlag("color=full") || hasFlag("color=truecolor")) {
      return 3;
    }
    if (hasFlag("color=256")) {
      return 2;
    }
  }
  if ("TF_BUILD" in env && "AGENT_NAME" in env) {
    return 1;
  }
  if (haveStream && !streamIsTTY && forceColor === void 0) {
    return 0;
  }
  const min = forceColor || 0;
  if (env.TERM === "dumb") {
    return min;
  }
  if (import_node_process.default.platform === "win32") {
    const osRelease = import_node_os.default.release().split(".");
    if (Number(osRelease[0]) >= 10 && Number(osRelease[2]) >= 10586) {
      return Number(osRelease[2]) >= 14931 ? 3 : 2;
    }
    return 1;
  }
  if ("CI" in env) {
    if ("GITHUB_ACTIONS" in env || "GITEA_ACTIONS" in env) {
      return 3;
    }
    if (["TRAVIS", "CIRCLECI", "APPVEYOR", "GITLAB_CI", "BUILDKITE", "DRONE"].some((sign) => sign in env) || env.CI_NAME === "codeship") {
      return 1;
    }
    return min;
  }
  if ("TEAMCITY_VERSION" in env) {
    return /^(9\.(0*[1-9]\d*)\.|\d{2,}\.)/.test(env.TEAMCITY_VERSION) ? 1 : 0;
  }
  if (env.COLORTERM === "truecolor") {
    return 3;
  }
  if (env.TERM === "xterm-kitty") {
    return 3;
  }
  if ("TERM_PROGRAM" in env) {
    const version2 = Number.parseInt((env.TERM_PROGRAM_VERSION || "").split(".")[0], 10);
    switch (env.TERM_PROGRAM) {
      case "iTerm.app": {
        return version2 >= 3 ? 3 : 2;
      }
      case "Apple_Terminal": {
        return 2;
      }
    }
  }
  if (/-256(color)?$/i.test(env.TERM)) {
    return 2;
  }
  if (/^screen|^xterm|^vt100|^vt220|^rxvt|color|ansi|cygwin|linux/i.test(env.TERM)) {
    return 1;
  }
  if ("COLORTERM" in env) {
    return 1;
  }
  return min;
}
function createSupportsColor(stream, options = {}) {
  const level = _supportsColor(stream, __spreadValues({
    streamIsTTY: stream && stream.isTTY
  }, options));
  return translateLevel(level);
}
var supportsColor = {
  stdout: createSupportsColor({ isTTY: import_node_tty.default.isatty(1) }),
  stderr: createSupportsColor({ isTTY: import_node_tty.default.isatty(2) })
};
var supports_color_default = supportsColor;

// node_modules/.pnpm/chalk@5.3.0/node_modules/chalk/source/utilities.js
function stringReplaceAll(string, substring, replacer) {
  let index = string.indexOf(substring);
  if (index === -1) {
    return string;
  }
  const substringLength = substring.length;
  let endIndex = 0;
  let returnValue = "";
  do {
    returnValue += string.slice(endIndex, index) + substring + replacer;
    endIndex = index + substringLength;
    index = string.indexOf(substring, endIndex);
  } while (index !== -1);
  returnValue += string.slice(endIndex);
  return returnValue;
}
function stringEncaseCRLFWithFirstIndex(string, prefix, postfix, index) {
  let endIndex = 0;
  let returnValue = "";
  do {
    const gotCR = string[index - 1] === "\r";
    returnValue += string.slice(endIndex, gotCR ? index - 1 : index) + prefix + (gotCR ? "\r\n" : "\n") + postfix;
    endIndex = index + 1;
    index = string.indexOf("\n", endIndex);
  } while (index !== -1);
  returnValue += string.slice(endIndex);
  return returnValue;
}

// node_modules/.pnpm/chalk@5.3.0/node_modules/chalk/source/index.js
var { stdout: stdoutColor, stderr: stderrColor } = supports_color_default;
var GENERATOR = Symbol("GENERATOR");
var STYLER = Symbol("STYLER");
var IS_EMPTY = Symbol("IS_EMPTY");
var levelMapping = [
  "ansi",
  "ansi",
  "ansi256",
  "ansi16m"
];
var styles2 = /* @__PURE__ */ Object.create(null);
var applyOptions = (object, options = {}) => {
  if (options.level && !(Number.isInteger(options.level) && options.level >= 0 && options.level <= 3)) {
    throw new Error("The `level` option should be an integer from 0 to 3");
  }
  const colorLevel = stdoutColor ? stdoutColor.level : 0;
  object.level = options.level === void 0 ? colorLevel : options.level;
};
var chalkFactory = (options) => {
  const chalk2 = (...strings) => strings.join(" ");
  applyOptions(chalk2, options);
  Object.setPrototypeOf(chalk2, createChalk.prototype);
  return chalk2;
};
function createChalk(options) {
  return chalkFactory(options);
}
Object.setPrototypeOf(createChalk.prototype, Function.prototype);
for (const [styleName, style] of Object.entries(ansi_styles_default)) {
  styles2[styleName] = {
    get() {
      const builder = createBuilder(this, createStyler(style.open, style.close, this[STYLER]), this[IS_EMPTY]);
      Object.defineProperty(this, styleName, { value: builder });
      return builder;
    }
  };
}
styles2.visible = {
  get() {
    const builder = createBuilder(this, this[STYLER], true);
    Object.defineProperty(this, "visible", { value: builder });
    return builder;
  }
};
var getModelAnsi = (model, level, type, ...arguments_) => {
  if (model === "rgb") {
    if (level === "ansi16m") {
      return ansi_styles_default[type].ansi16m(...arguments_);
    }
    if (level === "ansi256") {
      return ansi_styles_default[type].ansi256(ansi_styles_default.rgbToAnsi256(...arguments_));
    }
    return ansi_styles_default[type].ansi(ansi_styles_default.rgbToAnsi(...arguments_));
  }
  if (model === "hex") {
    return getModelAnsi("rgb", level, type, ...ansi_styles_default.hexToRgb(...arguments_));
  }
  return ansi_styles_default[type][model](...arguments_);
};
var usedModels = ["rgb", "hex", "ansi256"];
for (const model of usedModels) {
  styles2[model] = {
    get() {
      const { level } = this;
      return function(...arguments_) {
        const styler = createStyler(getModelAnsi(model, levelMapping[level], "color", ...arguments_), ansi_styles_default.color.close, this[STYLER]);
        return createBuilder(this, styler, this[IS_EMPTY]);
      };
    }
  };
  const bgModel = "bg" + model[0].toUpperCase() + model.slice(1);
  styles2[bgModel] = {
    get() {
      const { level } = this;
      return function(...arguments_) {
        const styler = createStyler(getModelAnsi(model, levelMapping[level], "bgColor", ...arguments_), ansi_styles_default.bgColor.close, this[STYLER]);
        return createBuilder(this, styler, this[IS_EMPTY]);
      };
    }
  };
}
var proto = Object.defineProperties(() => {
}, __spreadProps(__spreadValues({}, styles2), {
  level: {
    enumerable: true,
    get() {
      return this[GENERATOR].level;
    },
    set(level) {
      this[GENERATOR].level = level;
    }
  }
}));
var createStyler = (open, close, parent) => {
  let openAll;
  let closeAll;
  if (parent === void 0) {
    openAll = open;
    closeAll = close;
  } else {
    openAll = parent.openAll + open;
    closeAll = close + parent.closeAll;
  }
  return {
    open,
    close,
    openAll,
    closeAll,
    parent
  };
};
var createBuilder = (self, _styler, _isEmpty) => {
  const builder = (...arguments_) => applyStyle(builder, arguments_.length === 1 ? "" + arguments_[0] : arguments_.join(" "));
  Object.setPrototypeOf(builder, proto);
  builder[GENERATOR] = self;
  builder[STYLER] = _styler;
  builder[IS_EMPTY] = _isEmpty;
  return builder;
};
var applyStyle = (self, string) => {
  if (self.level <= 0 || !string) {
    return self[IS_EMPTY] ? "" : string;
  }
  let styler = self[STYLER];
  if (styler === void 0) {
    return string;
  }
  const { openAll, closeAll } = styler;
  if (string.includes("\x1B")) {
    while (styler !== void 0) {
      string = stringReplaceAll(string, styler.close, styler.open);
      styler = styler.parent;
    }
  }
  const lfIndex = string.indexOf("\n");
  if (lfIndex !== -1) {
    string = stringEncaseCRLFWithFirstIndex(string, closeAll, openAll, lfIndex);
  }
  return openAll + string + closeAll;
};
Object.defineProperties(createChalk.prototype, styles2);
var chalk = createChalk();
var chalkStderr = createChalk({ level: stderrColor ? stderrColor.level : 0 });
var source_default = chalk;

// node_modules/.pnpm/is-unicode-supported@1.3.0/node_modules/is-unicode-supported/index.js
var import_node_process2 = __toESM(require("process"), 1);
function isUnicodeSupported() {
  if (import_node_process2.default.platform !== "win32") {
    return import_node_process2.default.env.TERM !== "linux";
  }
  return Boolean(import_node_process2.default.env.CI) || Boolean(import_node_process2.default.env.WT_SESSION) || Boolean(import_node_process2.default.env.TERMINUS_SUBLIME) || import_node_process2.default.env.ConEmuTask === "{cmd::Cmder}" || import_node_process2.default.env.TERM_PROGRAM === "Terminus-Sublime" || import_node_process2.default.env.TERM_PROGRAM === "vscode" || import_node_process2.default.env.TERM === "xterm-256color" || import_node_process2.default.env.TERM === "alacritty" || import_node_process2.default.env.TERMINAL_EMULATOR === "JetBrains-JediTerm";
}

// node_modules/.pnpm/log-symbols@6.0.0/node_modules/log-symbols/index.js
var main = {
  info: source_default.blue("\u2139"),
  success: source_default.green("\u2714"),
  warning: source_default.yellow("\u26A0"),
  error: source_default.red("\u2716")
};
var fallback = {
  info: source_default.blue("i"),
  success: source_default.green("\u221A"),
  warning: source_default.yellow("\u203C"),
  error: source_default.red("\xD7")
};
var logSymbols = isUnicodeSupported() ? main : fallback;
var log_symbols_default = logSymbols;

// package.json
var version = "9.4.0";

// src/version-bump.ts
var import_node_process5 = __toESM(require("process"));
var ezSpawn3 = __toESM(require("@jsdevtools/ez-spawn"));
var import_picocolors2 = __toESM(require_picocolors());
var import_prompts2 = __toESM(require("prompts"));

// src/get-new-version.ts
var import_node_process3 = __toESM(require("process"));
var import_picocolors = __toESM(require_picocolors());
var import_prompts = __toESM(require("prompts"));
var import_semver = __toESM(require("semver"));

// src/release-type.ts
var prereleaseTypes = ["premajor", "preminor", "prepatch", "prerelease"];
var releaseTypes = prereleaseTypes.concat(["major", "minor", "patch", "next"]);
function isPrerelease(value) {
  return prereleaseTypes.includes(value);
}
function isReleaseType(value) {
  return releaseTypes.includes(value);
}

// src/get-new-version.ts
async function getNewVersion(operation) {
  const { release } = operation.options;
  const { currentVersion } = operation.state;
  switch (release.type) {
    case "prompt":
      return promptForNewVersion(operation);
    case "version":
      return operation.update({
        newVersion: new import_semver.SemVer(release.version, true).version
      });
    default:
      return operation.update({
        release: release.type,
        newVersion: getNextVersion(currentVersion, release)
      });
  }
}
function getNextVersion(currentVersion, bump) {
  const oldSemVer = new import_semver.SemVer(currentVersion);
  const type = bump.type === "next" ? oldSemVer.prerelease.length ? "prerelease" : "patch" : bump.type;
  const newSemVer = oldSemVer.inc(type, bump.preid);
  if (isPrerelease(bump.type) && newSemVer.prerelease.length === 2 && newSemVer.prerelease[0] === bump.preid && String(newSemVer.prerelease[1]) === "0") {
    newSemVer.prerelease[1] = "1";
    newSemVer.format();
  }
  return newSemVer.version;
}
function getNextVersions(currentVersion, preid) {
  const next = {};
  const parse = import_semver.default.parse(currentVersion);
  if (typeof (parse == null ? void 0 : parse.prerelease[0]) === "string")
    preid = (parse == null ? void 0 : parse.prerelease[0]) || "preid";
  for (const type of releaseTypes)
    next[type] = getNextVersion(currentVersion, { type, preid });
  return next;
}
async function promptForNewVersion(operation) {
  var _a, _b;
  const { currentVersion } = operation.state;
  const release = operation.options.release;
  const next = getNextVersions(currentVersion, release.preid);
  const configCustomVersion = await ((_b = (_a = operation.options).customVersion) == null ? void 0 : _b.call(_a, currentVersion, import_semver.default));
  const PADDING = 13;
  const answers = await (0, import_prompts.default)([
    {
      type: "autocomplete",
      name: "release",
      message: `Current version ${import_picocolors.default.green(currentVersion)}`,
      initial: configCustomVersion ? "config" : "next",
      choices: [
        { value: "major", title: `${"major".padStart(PADDING, " ")} ${import_picocolors.default.bold(next.major)}` },
        { value: "minor", title: `${"minor".padStart(PADDING, " ")} ${import_picocolors.default.bold(next.minor)}` },
        { value: "patch", title: `${"patch".padStart(PADDING, " ")} ${import_picocolors.default.bold(next.patch)}` },
        { value: "next", title: `${"next".padStart(PADDING, " ")} ${import_picocolors.default.bold(next.next)}` },
        ...configCustomVersion ? [
          { value: "config", title: `${"from config".padStart(PADDING, " ")} ${import_picocolors.default.bold(configCustomVersion)}` }
        ] : [],
        { value: "prepatch", title: `${"pre-patch".padStart(PADDING, " ")} ${import_picocolors.default.bold(next.prepatch)}` },
        { value: "preminor", title: `${"pre-minor".padStart(PADDING, " ")} ${import_picocolors.default.bold(next.preminor)}` },
        { value: "premajor", title: `${"pre-major".padStart(PADDING, " ")} ${import_picocolors.default.bold(next.premajor)}` },
        { value: "none", title: `${"as-is".padStart(PADDING, " ")} ${import_picocolors.default.bold(currentVersion)}` },
        { value: "custom", title: "custom ...".padStart(PADDING + 4, " ") }
      ]
    },
    {
      type: (prev) => prev === "custom" ? "text" : null,
      name: "custom",
      message: "Enter the new version number:",
      initial: currentVersion,
      validate: (custom) => {
        return (0, import_semver.valid)(custom) ? true : "That's not a valid version number";
      }
    }
  ]);
  const newVersion = answers.release === "none" ? currentVersion : answers.release === "custom" ? (0, import_semver.clean)(answers.custom) : answers.release === "config" ? (0, import_semver.clean)(configCustomVersion) : next[answers.release];
  if (!newVersion)
    import_node_process3.default.exit(1);
  switch (answers.release) {
    case "custom":
    case "config":
    case "next":
    case "none":
      return operation.update({ newVersion });
    default:
      return operation.update({ release: answers.release, newVersion });
  }
}

// src/get-current-version.ts
var import_semver2 = require("semver");

// src/fs.ts
var import_node_fs = __toESM(require("fs"));
var import_node_path = __toESM(require("path"));

// node_modules/.pnpm/detect-indent@7.0.1/node_modules/detect-indent/index.js
var INDENT_REGEX = /^(?:( )+|\t+)/;
var INDENT_TYPE_SPACE = "space";
var INDENT_TYPE_TAB = "tab";
function makeIndentsMap(string, ignoreSingleSpaces) {
  const indents = /* @__PURE__ */ new Map();
  let previousSize = 0;
  let previousIndentType;
  let key;
  for (const line of string.split(/\n/g)) {
    if (!line) {
      continue;
    }
    let indent;
    let indentType;
    let use;
    let weight;
    let entry;
    const matches = line.match(INDENT_REGEX);
    if (matches === null) {
      previousSize = 0;
      previousIndentType = "";
    } else {
      indent = matches[0].length;
      indentType = matches[1] ? INDENT_TYPE_SPACE : INDENT_TYPE_TAB;
      if (ignoreSingleSpaces && indentType === INDENT_TYPE_SPACE && indent === 1) {
        continue;
      }
      if (indentType !== previousIndentType) {
        previousSize = 0;
      }
      previousIndentType = indentType;
      use = 1;
      weight = 0;
      const indentDifference = indent - previousSize;
      previousSize = indent;
      if (indentDifference === 0) {
        use = 0;
        weight = 1;
      } else {
        const absoluteIndentDifference = indentDifference > 0 ? indentDifference : -indentDifference;
        key = encodeIndentsKey(indentType, absoluteIndentDifference);
      }
      entry = indents.get(key);
      entry = entry === void 0 ? [1, 0] : [entry[0] + use, entry[1] + weight];
      indents.set(key, entry);
    }
  }
  return indents;
}
function encodeIndentsKey(indentType, indentAmount) {
  const typeCharacter = indentType === INDENT_TYPE_SPACE ? "s" : "t";
  return typeCharacter + String(indentAmount);
}
function decodeIndentsKey(indentsKey) {
  const keyHasTypeSpace = indentsKey[0] === "s";
  const type = keyHasTypeSpace ? INDENT_TYPE_SPACE : INDENT_TYPE_TAB;
  const amount = Number(indentsKey.slice(1));
  return { type, amount };
}
function getMostUsedKey(indents) {
  let result;
  let maxUsed = 0;
  let maxWeight = 0;
  for (const [key, [usedCount, weight]] of indents) {
    if (usedCount > maxUsed || usedCount === maxUsed && weight > maxWeight) {
      maxUsed = usedCount;
      maxWeight = weight;
      result = key;
    }
  }
  return result;
}
function makeIndentString(type, amount) {
  const indentCharacter = type === INDENT_TYPE_SPACE ? " " : "	";
  return indentCharacter.repeat(amount);
}
function detectIndent(string) {
  if (typeof string !== "string") {
    throw new TypeError("Expected a string");
  }
  let indents = makeIndentsMap(string, true);
  if (indents.size === 0) {
    indents = makeIndentsMap(string, false);
  }
  const keyOfMostUsedIndent = getMostUsedKey(indents);
  let type;
  let amount = 0;
  let indent = "";
  if (keyOfMostUsedIndent !== void 0) {
    ({ type, amount } = decodeIndentsKey(keyOfMostUsedIndent));
    indent = makeIndentString(type, amount);
  }
  return {
    amount,
    type,
    indent
  };
}

// node_modules/.pnpm/detect-newline@4.0.1/node_modules/detect-newline/index.js
function detectNewline(string) {
  if (typeof string !== "string") {
    throw new TypeError("Expected a string");
  }
  const newlines = string.match(/(?:\r?\n)/g) || [];
  if (newlines.length === 0) {
    return;
  }
  const crlf = newlines.filter((newline) => newline === "\r\n").length;
  const lf = newlines.length - crlf;
  return crlf > lf ? "\r\n" : "\n";
}

// src/fs.ts
async function readJsonFile(name, cwd) {
  const file = await readTextFile(name, cwd);
  const data = JSON.parse(file.data);
  const indent = detectIndent(file.data).indent;
  const newline = detectNewline(file.data);
  return __spreadProps(__spreadValues({}, file), { data, indent, newline });
}
async function writeJsonFile(file) {
  let json = JSON.stringify(file.data, void 0, file.indent);
  if (file.newline)
    json += file.newline;
  return writeTextFile(__spreadProps(__spreadValues({}, file), { data: json }));
}
function readTextFile(name, cwd) {
  return new Promise((resolve, reject) => {
    const filePath = import_node_path.default.join(cwd, name);
    import_node_fs.default.readFile(filePath, "utf8", (err, text) => {
      if (err) {
        reject(err);
      } else {
        resolve({
          path: filePath,
          data: text
        });
      }
    });
  });
}
function writeTextFile(file) {
  return new Promise((resolve, reject) => {
    import_node_fs.default.writeFile(file.path, file.data, (err) => {
      if (err)
        reject(err);
      else
        resolve();
    });
  });
}

// src/manifest.ts
function isManifest(obj) {
  return obj && typeof obj === "object" && isOptionalString(obj.name) && isOptionalString(obj.version) && isOptionalString(obj.description);
}
function isPackageLockManifest(manifest) {
  var _a, _b;
  return typeof ((_b = (_a = manifest.packages) == null ? void 0 : _a[""]) == null ? void 0 : _b.version) === "string";
}
function isOptionalString(value) {
  const type = typeof value;
  return value === null || type === "undefined" || type === "string";
}

// src/get-current-version.ts
async function getCurrentVersion(operation) {
  if (operation.state.currentVersion)
    return operation;
  const { cwd, files } = operation.options;
  const filesToCheck = files.filter((file) => file.endsWith(".json"));
  if (!filesToCheck.includes("package.json"))
    filesToCheck.push("package.json");
  for (const file of filesToCheck) {
    const version2 = await readVersion(file, cwd);
    if (version2) {
      return operation.update({
        currentVersionSource: file,
        currentVersion: version2
      });
    }
  }
  throw new Error(
    `Unable to determine the current version number. Checked ${filesToCheck.join(", ")}.`
  );
}
async function readVersion(file, cwd) {
  try {
    const { data: manifest } = await readJsonFile(file, cwd);
    if (isManifest(manifest)) {
      if ((0, import_semver2.valid)(manifest.version))
        return manifest.version;
    }
  } catch (error) {
    return void 0;
  }
}

// src/git.ts
var ezSpawn = __toESM(require("@jsdevtools/ez-spawn"));
async function gitCommit(operation) {
  if (!operation.options.commit)
    return operation;
  const { all, noVerify, message } = operation.options.commit;
  const { updatedFiles, newVersion } = operation.state;
  let args = ["--allow-empty"];
  if (all) {
    args.push("--all");
  }
  if (noVerify) {
    args.push("--no-verify");
  }
  const commitMessage = formatVersionString(message, newVersion);
  args.push("--message", commitMessage);
  if (!all)
    args = args.concat(updatedFiles);
  await ezSpawn.async("git", ["commit", ...args]);
  return operation.update({ event: "git commit" /* GitCommit */, commitMessage });
}
async function gitTag(operation) {
  if (!operation.options.tag)
    return operation;
  const { commit, tag } = operation.options;
  const { newVersion } = operation.state;
  const args = [
    // Create an annotated tag, which is recommended for releases.
    // See https://git-scm.com/docs/git-tag
    "--annotate",
    // Use the same commit message for the tag
    "--message",
    formatVersionString(commit.message, newVersion)
  ];
  const tagName = formatVersionString(tag.name, newVersion);
  args.push(tagName);
  await ezSpawn.async("git", ["tag", ...args]);
  return operation.update({ event: "git tag" /* GitTag */, tagName });
}
async function gitPush(operation) {
  if (!operation.options.push)
    return operation;
  await ezSpawn.async("git", "push");
  if (operation.options.tag) {
    await ezSpawn.async("git", ["push", "--tags"]);
  }
  return operation.update({ event: "git push" /* GitPush */ });
}
function formatVersionString(template, newVersion) {
  if (template.includes("%s"))
    return template.replace(/%s/g, newVersion);
  else
    return template + newVersion;
}

// src/normalize-options.ts
var import_node_process4 = __toESM(require("process"));
var import_fast_glob = __toESM(require("fast-glob"));
async function normalizeOptions(raw) {
  var _a;
  const preid = typeof raw.preid === "string" ? raw.preid : "beta";
  const push = Boolean(raw.push);
  const all = Boolean(raw.all);
  const noVerify = Boolean(raw.noVerify);
  const cwd = raw.cwd || import_node_process4.default.cwd();
  const ignoreScripts = Boolean(raw.ignoreScripts);
  const execute = raw.execute;
  let release;
  if (!raw.release || raw.release === "prompt")
    release = { type: "prompt", preid };
  else if (isReleaseType(raw.release) || raw.release === "next")
    release = { type: raw.release, preid };
  else
    release = { type: "version", version: raw.release };
  let tag;
  if (typeof raw.tag === "string")
    tag = { name: raw.tag };
  else if (raw.tag)
    tag = { name: "v" };
  let commit;
  if (typeof raw.commit === "string")
    commit = { all, noVerify, message: raw.commit };
  else if (raw.commit || tag || push)
    commit = { all, noVerify, message: "chore: release v" };
  const files = await (0, import_fast_glob.default)(
    ((_a = raw.files) == null ? void 0 : _a.length) ? raw.files : ["package.json", "package-lock.json", "jsr.json", "jsr.jsonc"],
    {
      cwd,
      onlyFiles: true,
      ignore: [
        "**/{.git,node_modules,bower_components,__tests__,fixtures,fixture}/**"
      ]
    }
  );
  let ui;
  if (raw.interface === false) {
    ui = { input: false, output: false };
  } else if (raw.interface === true || !raw.interface) {
    ui = { input: import_node_process4.default.stdin, output: import_node_process4.default.stdout };
  } else {
    let _b = raw.interface, { input, output } = _b, other = __objRest(_b, ["input", "output"]);
    if (input === true || input !== false && !input)
      input = import_node_process4.default.stdin;
    if (output === true || output !== false && !output)
      output = import_node_process4.default.stdout;
    ui = __spreadValues({ input, output }, other);
  }
  if (release.type === "prompt" && !(ui.input && ui.output))
    throw new Error("Cannot prompt for the version number because input or output has been disabled.");
  return {
    release,
    commit,
    tag,
    push,
    files,
    cwd,
    interface: ui,
    ignoreScripts,
    execute,
    customVersion: raw.customVersion,
    currentVersion: raw.currentVersion
  };
}

// src/operation.ts
var Operation = class _Operation {
  /**
   * Private constructor.  Use the `Operation.start()` static method instead.
   */
  constructor(options, progress2) {
    /**
     * The current state of the operation.
     */
    this.state = {
      release: void 0,
      currentVersion: "",
      currentVersionSource: "",
      newVersion: "",
      commitMessage: "",
      tagName: "",
      updatedFiles: [],
      skippedFiles: []
    };
    this.options = options;
    this._progress = progress2;
    if (options.currentVersion) {
      this.update({
        currentVersion: options.currentVersion,
        currentVersionSource: "user"
      });
    }
  }
  /**
   * The results of the operation.
   */
  get results() {
    const options = this.options;
    const state = this.state;
    return {
      release: state.release,
      currentVersion: state.currentVersion,
      newVersion: state.newVersion,
      commit: options.commit ? state.commitMessage : false,
      tag: options.tag ? state.tagName : false,
      updatedFiles: state.updatedFiles.slice(),
      skippedFiles: state.skippedFiles.slice()
    };
  }
  /**
   * Starts a new `versionBump()` operation.
   */
  static async start(input) {
    const options = await normalizeOptions(input);
    return new _Operation(options, input.progress);
  }
  /**
   * Updates the operation state and results, and reports the updated progress to the user.
   */
  update(_a) {
    var _b = _a, { event, script } = _b, newState = __objRest(_b, ["event", "script"]);
    Object.assign(this.state, newState);
    if (event && this._progress) {
      this._progress(__spreadValues({ event, script }, this.results));
    }
    return this;
  }
};

// src/run-npm-script.ts
var ezSpawn2 = __toESM(require("@jsdevtools/ez-spawn"));
async function runNpmScript(script, operation) {
  const { cwd, ignoreScripts } = operation.options;
  if (!ignoreScripts) {
    const { data: manifest } = await readJsonFile("package.json", cwd);
    if (isManifest(manifest) && hasScript(manifest, script)) {
      await ezSpawn2.async("npm", ["run", script, "--silent"], { stdio: "inherit" });
      operation.update({ event: "npm script" /* NpmScript */, script });
    }
  }
  return operation;
}
function hasScript(manifest, script) {
  const scripts = manifest.scripts;
  if (scripts && typeof scripts === "object")
    return Boolean(scripts[script]);
  return false;
}

// src/update-files.ts
var path2 = __toESM(require("path"));
async function updateFiles(operation) {
  const { files } = operation.options;
  for (const relPath of files) {
    const modified = await updateFile(relPath, operation);
    if (modified) {
      operation.update({
        event: "file updated" /* FileUpdated */,
        updatedFiles: operation.state.updatedFiles.concat(relPath)
      });
    } else {
      operation.update({
        event: "file skipped" /* FileSkipped */,
        skippedFiles: operation.state.skippedFiles.concat(relPath)
      });
    }
  }
  return operation;
}
async function updateFile(relPath, operation) {
  const name = path2.basename(relPath).trim().toLowerCase();
  switch (name) {
    case "package.json":
    case "package-lock.json":
    case "bower.json":
    case "component.json":
    case "jsr.json":
      return updateManifestFile(relPath, operation);
    default:
      return updateTextFile(relPath, operation);
  }
}
async function updateManifestFile(relPath, operation) {
  const { cwd } = operation.options;
  const { newVersion } = operation.state;
  let modified = false;
  const file = await readJsonFile(relPath, cwd);
  if (isManifest(file.data) && file.data.version !== newVersion) {
    file.data.version = newVersion;
    if (isPackageLockManifest(file.data))
      file.data.packages[""].version = newVersion;
    await writeJsonFile(file);
    modified = true;
  }
  return modified;
}
async function updateTextFile(relPath, operation) {
  const { cwd } = operation.options;
  const { currentVersion, newVersion } = operation.state;
  const modified = false;
  const file = await readTextFile(relPath, cwd);
  if (file.data.includes(currentVersion)) {
    const sanitizedVersion = currentVersion.replace(/(\W)/g, "\\$1");
    const replacePattern = new RegExp(`(\\b|v)${sanitizedVersion}\\b`, "g");
    file.data = file.data.replace(replacePattern, `$1${newVersion}`);
    await writeTextFile(file);
    return true;
  }
  return modified;
}

// src/version-bump.ts
async function versionBump(arg = {}) {
  if (typeof arg === "string")
    arg = { release: arg };
  const operation = await Operation.start(arg);
  await getCurrentVersion(operation);
  await getNewVersion(operation);
  if (arg.confirm) {
    printSummary(operation);
    if (!await (0, import_prompts2.default)({
      name: "yes",
      type: "confirm",
      message: "Bump?",
      initial: true
    }).then((r) => r.yes))
      import_node_process5.default.exit(1);
  }
  await runNpmScript("preversion" /* PreVersion */, operation);
  await updateFiles(operation);
  if (operation.options.execute) {
    console.log(log_symbols_default.info, "Executing script", operation.options.execute);
    await ezSpawn3.async(operation.options.execute, { stdio: "inherit" });
    console.log(log_symbols_default.success, "Script finished");
  }
  await runNpmScript("version" /* Version */, operation);
  await gitCommit(operation);
  await gitTag(operation);
  await runNpmScript("postversion" /* PostVersion */, operation);
  await gitPush(operation);
  return operation.results;
}
function printSummary(operation) {
  console.log();
  console.log(`   files ${operation.options.files.map((i) => import_picocolors2.default.bold(i)).join("\n         ")}`);
  if (operation.options.commit)
    console.log(`  commit ${import_picocolors2.default.bold(formatVersionString(operation.options.commit.message, operation.state.newVersion))}`);
  if (operation.options.tag)
    console.log(`     tag ${import_picocolors2.default.bold(formatVersionString(operation.options.tag.name, operation.state.newVersion))}`);
  if (operation.options.execute)
    console.log(` execute ${import_picocolors2.default.bold(operation.options.execute)}`);
  if (operation.options.push)
    console.log(`    push ${import_picocolors2.default.cyan(import_picocolors2.default.bold("yes"))}`);
  console.log();
  console.log(`    from ${import_picocolors2.default.bold(operation.state.currentVersion)}`);
  console.log(`      to ${import_picocolors2.default.green(import_picocolors2.default.bold(operation.state.newVersion))}`);
  console.log();
}

// src/cli/parse-args.ts
var import_node_process7 = __toESM(require("process"));
var import_promises = __toESM(require("fs/promises"));
var import_node_fs2 = __toESM(require("fs"));
var import_semver3 = require("semver");
var import_cac = __toESM(require("cac"));
var import_picocolors3 = __toESM(require_picocolors());
var import_js_yaml = __toESM(require("js-yaml"));

// src/config.ts
var import_node_process6 = __toESM(require("process"));
var import_node_path2 = require("path");
var import_c12 = require("c12");
var import_sync = __toESM(require("escalade/sync"));
var bumpConfigDefaults = {
  commit: true,
  push: true,
  tag: true,
  recursive: false,
  noVerify: false,
  confirm: true,
  ignoreScripts: false,
  all: false,
  files: []
};
async function loadBumpConfig(overrides, cwd = import_node_process6.default.cwd()) {
  const name = "bump";
  const configFile = findConfigFile(name, cwd);
  const { config } = await (0, import_c12.loadConfig)({
    name,
    defaults: bumpConfigDefaults,
    overrides: __spreadValues({}, overrides),
    cwd: configFile ? (0, import_node_path2.dirname)(configFile) : cwd
  });
  return config;
}
function findConfigFile(name, cwd) {
  let foundRepositoryRoot = false;
  try {
    const candidates = ["js", "mjs", "ts", "mts", "json"].map((ext) => `${name}.config.${ext}`);
    return (0, import_sync.default)(cwd, (_dir, files) => {
      const match = files.find((file) => {
        if (candidates.includes(file))
          return true;
        if (file === ".git")
          foundRepositoryRoot = true;
        return false;
      });
      if (match)
        return match;
      if (foundRepositoryRoot) {
        throw null;
      }
      return false;
    });
  } catch (error) {
    if (foundRepositoryRoot)
      return null;
    throw error;
  }
}

// src/cli/parse-args.ts
async function parseArgs() {
  var _a;
  try {
    const { args, resultArgs } = loadCliArgs();
    const parsedArgs = {
      help: args.help,
      version: args.version,
      quiet: args.quiet,
      options: await loadBumpConfig({
        preid: args.preid,
        commit: args.commit,
        tag: args.tag,
        push: args.push,
        all: args.all,
        confirm: !args.yes,
        noVerify: !args.verify,
        files: [...args["--"] || [], ...resultArgs],
        ignoreScripts: args.ignoreScripts,
        currentVersion: args.currentVersion,
        execute: args.execute,
        recursive: !!args.recursive
      })
    };
    if (parsedArgs.options.files && parsedArgs.options.files.length > 0) {
      const firstArg = parsedArgs.options.files[0];
      if (firstArg === "prompt" || isReleaseType(firstArg) || (0, import_semver3.valid)(firstArg)) {
        parsedArgs.options.release = firstArg;
        parsedArgs.options.files.shift();
      }
    }
    if (parsedArgs.options.recursive) {
      if ((_a = parsedArgs.options.files) == null ? void 0 : _a.length) {
        console.log(import_picocolors3.default.yellow("The --recursive option is ignored when files are specified"));
      } else {
        parsedArgs.options.files = [
          "package.json",
          "package-lock.json",
          "packages/**/package.json",
          "jsr.json",
          "jsr.jsonc"
        ];
        if (import_node_fs2.default.existsSync("pnpm-workspace.yaml")) {
          const pnpmWorkspace = await import_promises.default.readFile("pnpm-workspace.yaml", "utf8");
          const workspaces = import_js_yaml.default.load(pnpmWorkspace);
          const workspacesWithPackageJson = workspaces.packages.map((workspace) => `${workspace}/package.json`);
          const withoutExcludedWorkspaces = workspacesWithPackageJson.filter((workspace) => {
            var _a2;
            return !workspace.startsWith("!") && !((_a2 = parsedArgs.options.files) == null ? void 0 : _a2.includes(workspace));
          });
          parsedArgs.options.files = parsedArgs.options.files.concat(withoutExcludedWorkspaces);
        }
      }
    }
    return parsedArgs;
  } catch (error) {
    return errorHandler(error);
  }
}
function loadCliArgs(argv = import_node_process7.default.argv) {
  const cli = (0, import_cac.default)("bumpp");
  cli.version(version).usage("[...files]").option("--preid <preid>", "ID for prerelease").option("--all", `Include all files (default: ${bumpConfigDefaults.all})`).option("-c, --commit [msg]", "Commit message", { default: true }).option("--no-commit", "Skip commit", { default: false }).option("-t, --tag [tag]", "Tag name", { default: true }).option("--no-tag", "Skip tag", { default: false }).option("-p, --push", `Push to remote (default: ${bumpConfigDefaults.push})`).option("-y, --yes", `Skip confirmation (default: ${!bumpConfigDefaults.confirm})`).option("-r, --recursive", `Bump package.json files recursively (default: ${bumpConfigDefaults.recursive})`).option("--no-verify", "Skip git verification").option("--ignore-scripts", `Ignore scripts (default: ${bumpConfigDefaults.ignoreScripts})`).option("-q, --quiet", "Quiet mode").option("-v, --version <version>", "Target version").option("--current-version <version>", "Current version").option("-x, --execute <command>", "Commands to execute after version bumps").help();
  const result = cli.parse(argv);
  const rawArgs = cli.rawArgs;
  const args = result.options;
  const hasCommitFlag = rawArgs.some((arg) => ["-c", "--commit", "--no-commit"].includes(arg));
  const hasTagFlag = rawArgs.some((arg) => ["-t", "--tag", "--no-tag"].includes(arg));
  const _a = args, { tag, commit } = _a, rest = __objRest(_a, ["tag", "commit"]);
  return {
    args: __spreadProps(__spreadValues({}, rest), {
      commit: hasCommitFlag ? commit : void 0,
      tag: hasTagFlag ? tag : void 0
    }),
    resultArgs: result.args
  };
}
function errorHandler(error) {
  console.error(error.message);
  return import_node_process7.default.exit(9 /* InvalidArgument */);
}

// src/cli/index.ts
async function main2() {
  try {
    import_node_process8.default.on("uncaughtException", errorHandler2);
    import_node_process8.default.on("unhandledRejection", errorHandler2);
    const { help, version: version2, quiet, options } = await parseArgs();
    if (help) {
      import_node_process8.default.exit(0 /* Success */);
    } else if (version2) {
      console.log(version);
      import_node_process8.default.exit(0 /* Success */);
    } else {
      if (!quiet)
        options.progress = options.progress ? options.progress : progress;
      await versionBump(options);
    }
  } catch (error) {
    errorHandler2(error);
  }
}
function progress({ event, script, updatedFiles, skippedFiles, newVersion }) {
  switch (event) {
    case "file updated" /* FileUpdated */:
      console.log(log_symbols_default.success, `Updated ${updatedFiles.pop()} to ${newVersion}`);
      break;
    case "file skipped" /* FileSkipped */:
      console.log(log_symbols_default.info, `${skippedFiles.pop()} did not need to be updated`);
      break;
    case "git commit" /* GitCommit */:
      console.log(log_symbols_default.success, "Git commit");
      break;
    case "git tag" /* GitTag */:
      console.log(log_symbols_default.success, "Git tag");
      break;
    case "git push" /* GitPush */:
      console.log(log_symbols_default.success, "Git push");
      break;
    case "npm script" /* NpmScript */:
      console.log(log_symbols_default.success, `Npm run ${script}`);
      break;
  }
}
function errorHandler2(error) {
  let message = error.message || String(error);
  if (import_node_process8.default.env.DEBUG || import_node_process8.default.env.NODE_ENV === "development")
    message = error.stack || message;
  console.error(message);
  import_node_process8.default.exit(1 /* FatalError */);
}
// Annotate the CommonJS export names for ESM import in node:
0 && (module.exports = {
  main
});
