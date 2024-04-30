"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.DtsContent = void 0;
const promises_1 = __importDefault(require("node:fs/promises"));
const node_path_1 = __importDefault(require("node:path"));
const is_there_1 = __importDefault(require("is-there"));
const mkdirp_1 = require("mkdirp");
const camelcase_1 = __importDefault(require("camelcase"));
const chalk_1 = __importDefault(require("chalk"));
class DtsContent {
    constructor(options) {
        this.dropExtension = options.dropExtension;
        this.rootDir = options.rootDir;
        this.searchDir = options.searchDir;
        this.outDir = options.outDir;
        this.rInputPath = options.rInputPath;
        this.rawTokenList = options.rawTokenList;
        this.namedExports = options.namedExports;
        this.allowArbitraryExtensions = options.allowArbitraryExtensions;
        this.camelCase = options.camelCase;
        this.EOL = options.EOL;
        // when using named exports, camelCase must be enabled by default
        // (see https://webpack.js.org/loaders/css-loader/#namedexport)
        // we still accept external control for the 'dashes' option,
        // so we only override in case is false or undefined
        if (this.namedExports && !this.camelCase) {
            this.camelCase = true;
        }
        this.resultList = this.createResultList();
    }
    get contents() {
        return this.resultList;
    }
    get formatted() {
        if (!this.resultList || !this.resultList.length)
            return 'export {};';
        if (this.namedExports) {
            return (['export const __esModule: true;', ...this.resultList.map(line => 'export ' + line), ''].join(this.EOL) +
                this.EOL);
        }
        return (['declare const styles: {', ...this.resultList.map(line => '  ' + line), '};', 'export = styles;', ''].join(this.EOL) + this.EOL);
    }
    get tokens() {
        return this.rawTokenList;
    }
    get outputFilePath() {
        return node_path_1.default.join(this.rootDir, this.outDir, this.outputFileName);
    }
    get relativeOutputFilePath() {
        return node_path_1.default.join(this.outDir, this.outputFileName);
    }
    get inputFilePath() {
        return node_path_1.default.join(this.rootDir, this.searchDir, this.rInputPath);
    }
    get relativeInputFilePath() {
        return node_path_1.default.join(this.searchDir, this.rInputPath);
    }
    async checkFile(postprocessor = (formatted) => formatted) {
        if (!(0, is_there_1.default)(this.outputFilePath)) {
            console.error(chalk_1.default.red(`[ERROR] Type file needs to be generated for '${this.relativeInputFilePath}'`));
            return false;
        }
        const finalOutput = postprocessor(this.formatted);
        const fileContent = (await promises_1.default.readFile(this.outputFilePath)).toString();
        if (fileContent !== finalOutput) {
            console.error(chalk_1.default.red(`[ERROR] Check type definitions for '${this.relativeOutputFilePath}'`));
            return false;
        }
        return true;
    }
    async writeFile(postprocessor = formatted => formatted) {
        const finalOutput = await postprocessor(this.formatted);
        const outPathDir = node_path_1.default.dirname(this.outputFilePath);
        if (!(0, is_there_1.default)(outPathDir)) {
            await (0, mkdirp_1.mkdirp)(outPathDir);
        }
        let isDirty = false;
        if (!(0, is_there_1.default)(this.outputFilePath)) {
            isDirty = true;
        }
        else {
            const content = (await promises_1.default.readFile(this.outputFilePath)).toString();
            if (content !== finalOutput) {
                isDirty = true;
            }
        }
        if (isDirty) {
            await promises_1.default.writeFile(this.outputFilePath, finalOutput, 'utf8');
        }
    }
    async deleteFile() {
        if ((0, is_there_1.default)(this.outputFilePath)) {
            await promises_1.default.unlink(this.outputFilePath);
        }
    }
    createResultList() {
        const convertKey = this.getConvertKeyMethod(this.camelCase);
        const result = this.rawTokenList
            .map(k => convertKey(k))
            .map(k => (!this.namedExports ? 'readonly "' + k + '": string;' : 'const ' + k + ': string;'))
            .sort();
        return result;
    }
    getConvertKeyMethod(camelCaseOption) {
        switch (camelCaseOption) {
            case true:
                return camelcase_1.default;
            case 'dashes':
                return this.dashesCamelCase;
            default:
                return key => key;
        }
    }
    /**
     * Replaces only the dashes and leaves the rest as-is.
     *
     * Mirrors the behaviour of the css-loader:
     * https://github.com/webpack-contrib/css-loader/blob/1fee60147b9dba9480c9385e0f4e581928ab9af9/lib/compile-exports.js#L3-L7
     */
    dashesCamelCase(str) {
        return str.replace(/-+(\w)/g, (_, firstLetter) => firstLetter.toUpperCase());
    }
    get outputFileName() {
        // Original extension must be dropped when using the allowArbitraryExtensions option
        const outputFileName = this.dropExtension || this.allowArbitraryExtensions ? removeExtension(this.rInputPath) : this.rInputPath;
        /**
         * Handles TypeScript 5.0 addition of arbitrary file extension patterns for ESM compatibility
         * https://www.typescriptlang.org/tsconfig#allowArbitraryExtensions
         */
        return outputFileName + (this.allowArbitraryExtensions ? '.d.css.ts' : '.d.ts');
    }
}
exports.DtsContent = DtsContent;
function removeExtension(filePath) {
    const ext = node_path_1.default.extname(filePath);
    return filePath.replace(new RegExp(ext + '$'), '');
}
//# sourceMappingURL=dts-content.js.map