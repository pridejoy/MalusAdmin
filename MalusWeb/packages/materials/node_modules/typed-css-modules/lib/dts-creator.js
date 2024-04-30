"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.DtsCreator = void 0;
const node_process_1 = __importDefault(require("node:process"));
const node_path_1 = __importDefault(require("node:path"));
const node_os_1 = __importDefault(require("node:os"));
const file_system_loader_1 = __importDefault(require("./file-system-loader"));
const dts_content_1 = require("./dts-content");
class DtsCreator {
    constructor(options) {
        if (!options)
            options = {};
        this.rootDir = options.rootDir || node_process_1.default.cwd();
        this.searchDir = options.searchDir || '';
        this.outDir = options.outDir || this.searchDir;
        this.loader = new file_system_loader_1.default(this.rootDir, options.loaderPlugins);
        this.inputDirectory = node_path_1.default.join(this.rootDir, this.searchDir);
        this.camelCase = options.camelCase;
        this.namedExports = !!options.namedExports;
        this.allowArbitraryExtensions = !!options.allowArbitraryExtensions;
        this.dropExtension = !!options.dropExtension;
        this.EOL = options.EOL || node_os_1.default.EOL;
    }
    async create(filePath, initialContents, clearCache = false, isDelete = false) {
        let rInputPath;
        if (node_path_1.default.isAbsolute(filePath)) {
            rInputPath = node_path_1.default.relative(this.inputDirectory, filePath);
        }
        else {
            rInputPath = node_path_1.default.relative(this.inputDirectory, node_path_1.default.join(node_process_1.default.cwd(), filePath));
        }
        if (clearCache) {
            this.loader.tokensByFile = {};
        }
        let keys = [];
        if (!isDelete) {
            const res = await this.loader.fetch(filePath, '/', undefined, initialContents);
            if (!res)
                throw res;
            keys = Object.keys(res);
        }
        const content = new dts_content_1.DtsContent({
            dropExtension: this.dropExtension,
            rootDir: this.rootDir,
            searchDir: this.searchDir,
            outDir: this.outDir,
            rInputPath,
            rawTokenList: keys,
            namedExports: this.namedExports,
            allowArbitraryExtensions: this.allowArbitraryExtensions,
            camelCase: this.camelCase,
            EOL: this.EOL,
        });
        return content;
    }
}
exports.DtsCreator = DtsCreator;
//# sourceMappingURL=dts-creator.js.map