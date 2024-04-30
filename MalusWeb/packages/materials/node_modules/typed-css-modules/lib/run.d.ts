interface RunOptions {
    pattern?: string;
    outDir?: string;
    watch?: boolean;
    camelCase?: boolean;
    namedExports?: boolean;
    allowArbitraryExtensions?: boolean;
    dropExtension?: boolean;
    silent?: boolean;
    listDifferent?: boolean;
}
export declare function run(searchDir: string, options?: RunOptions): Promise<void>;
export {};
