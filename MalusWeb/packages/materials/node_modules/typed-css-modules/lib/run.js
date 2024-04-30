"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.run = void 0;
const chalk_1 = __importDefault(require("chalk"));
const chokidar_1 = __importDefault(require("chokidar"));
const glob_1 = require("glob");
const dts_creator_1 = require("./dts-creator");
async function run(searchDir, options = {}) {
    const filesPattern = searchDir.replace(/\\/g, '/') + '/' + (options.pattern || '**/*.css');
    const creator = new dts_creator_1.DtsCreator({
        rootDir: process.cwd(),
        searchDir,
        outDir: options.outDir,
        camelCase: options.camelCase,
        namedExports: options.namedExports,
        allowArbitraryExtensions: options.allowArbitraryExtensions,
        dropExtension: options.dropExtension,
    });
    const checkFile = async (f) => {
        try {
            const content = await creator.create(f, undefined, false);
            return await content.checkFile();
        }
        catch (error) {
            console.error(chalk_1.default.red(`[ERROR] An error occurred checking '${f}':\n${error}`));
            return false;
        }
    };
    const writeFile = async (f) => {
        try {
            const content = await creator.create(f, undefined, !!options.watch);
            await content.writeFile();
            if (!options.silent) {
                console.log('Wrote ' + chalk_1.default.green(content.outputFilePath));
            }
        }
        catch (error) {
            console.error(chalk_1.default.red('[Error] ' + error));
        }
    };
    const deleteFile = async (f) => {
        try {
            const content = await creator.create(f, undefined, !!options.watch, true);
            await content.deleteFile();
            console.log('Delete ' + chalk_1.default.green(content.outputFilePath));
        }
        catch (error) {
            console.error(chalk_1.default.red('[Error] ' + error));
        }
    };
    if (options.listDifferent) {
        const files = await (0, glob_1.glob)(filesPattern);
        const hasErrors = (await Promise.all(files.map(checkFile))).includes(false);
        if (hasErrors) {
            process.exit(1);
        }
        return;
    }
    if (!options.watch) {
        const files = await (0, glob_1.glob)(filesPattern);
        await Promise.all(files.map(writeFile));
    }
    else {
        console.log('Watch ' + filesPattern + '...');
        const watcher = chokidar_1.default.watch([filesPattern]);
        watcher.on('add', writeFile);
        watcher.on('change', writeFile);
        watcher.on('unlink', deleteFile);
        await waitForever();
    }
}
exports.run = run;
async function waitForever() {
    return new Promise(() => { });
}
//# sourceMappingURL=run.js.map