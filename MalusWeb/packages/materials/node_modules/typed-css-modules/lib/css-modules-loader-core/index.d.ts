declare class Core {
    constructor(plugins: any);
    plugins: any;
    load(sourceString: any, sourcePath: any, trace: any, pathFetcher: any): Promise<{
        injectableSource: string;
        exportTokens: {};
    }>;
}
declare namespace Core {
    let defaultPlugins: any[];
}
export default Core;
