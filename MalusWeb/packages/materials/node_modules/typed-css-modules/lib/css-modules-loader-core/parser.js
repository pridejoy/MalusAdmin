"use strict";
// Copied from https://github.com/css-modules/css-modules-loader-core
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const importRegexp = /^:import\((.+)\)$/;
const icss_replace_symbols_1 = __importDefault(require("icss-replace-symbols"));
class Parser {
    constructor(pathFetcher, trace) {
        this.pathFetcher = pathFetcher;
        this.plugin = this.plugin.bind(this);
        this.exportTokens = {};
        this.translations = {};
        this.trace = trace;
    }
    plugin(css) {
        return Promise.all(this.fetchAllImports(css))
            .then(() => this.linkImportedSymbols(css))
            .then(() => this.extractExports(css));
    }
    fetchAllImports(css) {
        let imports = [];
        css.each(node => {
            if (node.type == 'rule' && node.selector.match(importRegexp)) {
                imports.push(this.fetchImport(node, css.source.input.from, imports.length));
            }
        });
        return imports;
    }
    linkImportedSymbols(css) {
        (0, icss_replace_symbols_1.default)(css, this.translations);
    }
    extractExports(css) {
        css.each(node => {
            if (node.type == 'rule' && node.selector == ':export')
                this.handleExport(node);
        });
    }
    handleExport(exportNode) {
        exportNode.each(decl => {
            if (decl.type == 'decl') {
                Object.keys(this.translations).forEach(translation => {
                    decl.value = decl.value.replace(translation, this.translations[translation]);
                });
                this.exportTokens[decl.prop] = decl.value;
            }
        });
        exportNode.remove();
    }
    fetchImport(importNode, relativeTo, depNr) {
        let file = importNode.selector.match(importRegexp)[1], depTrace = this.trace + String.fromCharCode(depNr);
        return this.pathFetcher(file, relativeTo, depTrace).then(exports => {
            importNode.each(decl => {
                if (decl.type == 'decl') {
                    this.translations[decl.prop] = exports[decl.value];
                }
            });
            importNode.remove();
        }, err => console.log(err));
    }
}
exports.default = Parser;
//# sourceMappingURL=parser.js.map