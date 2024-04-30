export type CamelCaseOption = boolean | 'dashes' | undefined;
interface DtsContentOptions {
    dropExtension: boolean;
    rootDir: string;
    searchDir: string;
    outDir: string;
    rInputPath: string;
    rawTokenList: string[];
    namedExports: boolean;
    allowArbitraryExtensions: boolean;
    camelCase: CamelCaseOption;
    EOL: string;
}
export declare class DtsContent {
    private dropExtension;
    private rootDir;
    private searchDir;
    private outDir;
    private rInputPath;
    private rawTokenList;
    private namedExports;
    private allowArbitraryExtensions;
    private camelCase;
    private resultList;
    private EOL;
    constructor(options: DtsContentOptions);
    get contents(): string[];
    get formatted(): string;
    get tokens(): string[];
    get outputFilePath(): string;
    get relativeOutputFilePath(): string;
    get inputFilePath(): string;
    get relativeInputFilePath(): string;
    checkFile(postprocessor?: (formatted: string) => string): Promise<boolean>;
    writeFile(postprocessor?: (formatted: string) => string | PromiseLike<string>): Promise<void>;
    deleteFile(): Promise<void>;
    private createResultList;
    private getConvertKeyMethod;
    /**
     * Replaces only the dashes and leaves the rest as-is.
     *
     * Mirrors the behaviour of the css-loader:
     * https://github.com/webpack-contrib/css-loader/blob/1fee60147b9dba9480c9385e0f4e581928ab9af9/lib/compile-exports.js#L3-L7
     */
    private dashesCamelCase;
    private get outputFileName();
}
export {};
