import { Plugin } from 'postcss';
import { DtsContent, CamelCaseOption } from './dts-content';
interface DtsCreatorOptions {
    rootDir?: string;
    searchDir?: string;
    outDir?: string;
    camelCase?: CamelCaseOption;
    namedExports?: boolean;
    allowArbitraryExtensions?: boolean;
    dropExtension?: boolean;
    EOL?: string;
    loaderPlugins?: Plugin[];
}
export declare class DtsCreator {
    private rootDir;
    private searchDir;
    private outDir;
    private loader;
    private inputDirectory;
    private camelCase;
    private namedExports;
    private allowArbitraryExtensions;
    private dropExtension;
    private EOL;
    constructor(options?: DtsCreatorOptions);
    create(filePath: string, initialContents?: string, clearCache?: boolean, isDelete?: boolean): Promise<DtsContent>;
}
export {};
