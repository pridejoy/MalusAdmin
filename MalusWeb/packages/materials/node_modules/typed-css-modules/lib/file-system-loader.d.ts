import type { Plugin } from 'postcss';
import { type ExportTokens } from './css-modules-loader-core';
type Dictionary<T> = {
    [key: string]: T | undefined;
};
export default class FileSystemLoader {
    private root;
    private sources;
    private importNr;
    private core;
    tokensByFile: Dictionary<ExportTokens>;
    constructor(root: string, plugins?: Plugin[]);
    fetch(_newPath: string, relativeTo: string, _trace?: string, initialContents?: string): Promise<ExportTokens>;
}
export {};
