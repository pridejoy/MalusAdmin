export default class Parser {
    constructor(pathFetcher: any, trace: any);
    pathFetcher: any;
    plugin(css: any): Promise<void>;
    exportTokens: {};
    translations: {};
    trace: any;
    fetchAllImports(css: any): any[];
    linkImportedSymbols(css: any): void;
    extractExports(css: any): void;
    handleExport(exportNode: any): void;
    fetchImport(importNode: any, relativeTo: any, depNr: any): any;
}
