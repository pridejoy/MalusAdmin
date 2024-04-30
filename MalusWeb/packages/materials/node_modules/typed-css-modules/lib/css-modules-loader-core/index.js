"use strict";
// Copied from https://github.com/css-modules/css-modules-loader-core
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const postcss_1 = __importDefault(require("postcss"));
const postcss_modules_local_by_default_1 = __importDefault(require("postcss-modules-local-by-default"));
const postcss_modules_extract_imports_1 = __importDefault(require("postcss-modules-extract-imports"));
const postcss_modules_scope_1 = __importDefault(require("postcss-modules-scope"));
const postcss_modules_values_1 = __importDefault(require("postcss-modules-values"));
const parser_1 = __importDefault(require("./parser"));
class Core {
    constructor(plugins) {
        this.plugins = plugins || Core.defaultPlugins;
    }
    load(sourceString, sourcePath, trace, pathFetcher) {
        let parser = new parser_1.default(pathFetcher, trace);
        return (0, postcss_1.default)(this.plugins.concat([parser.plugin]))
            .process(sourceString, { from: '/' + sourcePath })
            .then(result => {
            return {
                injectableSource: result.css,
                exportTokens: parser.exportTokens,
            };
        });
    }
}
exports.default = Core;
Core.defaultPlugins = [postcss_modules_values_1.default, postcss_modules_local_by_default_1.default, postcss_modules_extract_imports_1.default, postcss_modules_scope_1.default];
//# sourceMappingURL=index.js.map