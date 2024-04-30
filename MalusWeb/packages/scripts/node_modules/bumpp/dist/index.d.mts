import _semver, { ReleaseType as ReleaseType$1 } from 'semver';

type ReleaseType = ReleaseType$1 | 'next';

/**
 * Information about the work that was performed by the `versionBump()` function.
 */
interface VersionBumpResults {
    /**
     * The release type that was used, or `undefined` if an explicit version number was used.
     */
    release?: ReleaseType;
    /**
     * The previous version number in package.json.
     */
    currentVersion: string;
    /**
     * The new version number.
     */
    newVersion: string;
    /**
     * The commit message that was used for the git commit, or `false` if no git commit was created.
     *
     * NOTE: This will never be an empty string.  It will always contain at least the new version number.
     */
    commit: string | false;
    /**
     * The tag name that was used for the git tag, or `false` if no git tag was created.
     *
     * NOTE: This will never be an empty string.  It will always contain at least the new version number.
     */
    tag: string | false;
    /**
     * The files that were actually modified.
     */
    updatedFiles: string[];
    /**
     * The files that were not updated because they did not contain the old version number.
     */
    skippedFiles: string[];
}

/**
 * Progress events that indicate the progress of the `versionBump()` function.
 */
declare const enum ProgressEvent {
    FileUpdated = "file updated",
    FileSkipped = "file skipped",
    GitCommit = "git commit",
    GitTag = "git tag",
    GitPush = "git push",
    NpmScript = "npm script"
}
/**
 * The NPM version scripts
 *
 * @see https://docs.npmjs.com/cli/version.html
 */
declare const enum NpmScript {
    PreVersion = "preversion",
    Version = "version",
    PostVersion = "postversion"
}
/**
 * Information about the progress of the `versionBump()` function.
 */
interface VersionBumpProgress extends VersionBumpResults {
    event: ProgressEvent;
    script?: NpmScript;
}

/**
 * Options for the `versionBump()` function.
 */
interface VersionBumpOptions {
    /**
     * The release version or type. Can be one of the following:
     *
     * - The new version number (e.g. "1.23.456")
     * - A release type (e.g. "major", "minor", "patch", "prerelease", etc.)
     * - "prompt" to prompt the user for the version number
     *
     * Defaults to "prompt".
     */
    release?: string;
    /**
     * The current version number to be bumpped.
     * If not provide, it will be read from the first file in the `files` array.
     */
    currentVersion?: string;
    /**
     * The prerelease type (e.g. "alpha", "beta", "next").
     *
     * Defaults to "beta".
     */
    preid?: string;
    /**
     * Indicates whether to create a git commit. Can be set to a custom commit message string
     * or `true` to use "release v".  Any `%s` placeholders in the message string will be replaced
     * with the new version number.  If the message string does _not_ contain any `%s` placeholders,
     * then the new version number will be appended to the message.
     *
     * Defaults to `false`.
     */
    commit?: boolean | string;
    /**
     * Indicates whether to tag the git commit. Can be set to a custom tag string
     * or `true` to use "v".  Any `%s` placeholders in the tag string will be replaced
     * with the new version number.  If the tag string does _not_ contain any `%s` placeholders,
     * then the new version number will be appended to the tag.
     *
     * Defaults to `false`.
     */
    tag?: boolean | string;
    /**
     * Indicates whether to push the git commit and tag.
     *
     * Defaults to `false`.
     */
    push?: boolean;
    /**
     * Indicates whether the git commit should include ALL files (`git commit --all`)
     * rather than just the files that were modified by `versionBump()`.
     *
     * Defaults to `false`.
     */
    all?: boolean;
    /**
     * Prompt for confirmation
     *
     * @default false
     */
    confirm?: boolean;
    /**
     * Indicates whether to bypass git commit hooks (`git commit --no-verify`).
     *
     * Defaults to `false`.
     */
    noVerify?: boolean;
    /**
     * The files to be updated. For certain known files ("package.json", "bower.json", etc.)
     * `versionBump()` will explicitly update the file's version number.  For other files
     * (ReadMe files, config files, source code, etc.) it will simply do a global replacement
     * of the old version number with the new version number.
     *
     * Defaults to ["package.json", "package-lock.json", "jsr.json", "jsr.jsonc"]
     */
    files?: string[];
    /**
     * The working directory, which is used as the basis for locating all files.
     *
     * Defaults to `process.cwd()`
     */
    cwd?: string;
    /**
     * Options for the command-line interface. Can be one of the following:
     *
     * - `true` - To default to `process.stdin` and `process.stdout`.
     * - `false` - To disable all CLI output. Cannot be used when `release` is "prompt".
     * - An object that will be passed to `readline.createInterface()`.
     *
     * Defaults to `true`.
     */
    interface?: boolean | InterfaceOptions;
    /**
     * Indicates whether to ignore version scripts.
     *
     * Defaults to `false`.
     */
    ignoreScripts?: boolean;
    /**
     * A callback that is provides information about the progress of the `versionBump()` function.
     */
    progress?: (progress: VersionBumpProgress) => void;
    /**
     * Excute additional command after bumping and before commiting
     */
    execute?: string;
    /**
     * Bump the files recursively for monorepo. Only works without `files` option.
     *
     * @default false
     */
    recursive?: boolean;
    /**
     * Custom function to provide the version number
     */
    customVersion?: (currentVersion: string, semver: typeof _semver) => Promise<string | void> | string | void;
}
/**
 * Options for the command-line interface.
 */
interface InterfaceOptions {
    /**
     * The stream that will be used to read user input.  Can be one of the following:
     *
     * - `true` - To default to `process.stdin`
     * - `false` - To disable all CLI input
     * - Any readable stream
     *
     * Defaults to `true`.
     */
    input?: NodeJS.ReadableStream | NodeJS.ReadStream | boolean;
    /**
     * The stream that will be used to write output, such as prompts and progress.
     * Can be one of the following:
     *
     * - `true` - To default to `process.stdout`
     * - `false` - To disable all CLI output
     * - Any writable stream
     *
     * Defaults to `true`.
     */
    output?: NodeJS.WritableStream | NodeJS.WriteStream | boolean;
    /**
     * Any other properties will be passed directly to `readline.createInterface()`.
     * See the `ReadLineOptions` interface for possible options.
     */
    [key: string]: unknown;
}

interface Interface {
    input?: NodeJS.ReadableStream | NodeJS.ReadStream | false;
    output?: NodeJS.WritableStream | NodeJS.WriteStream | false;
    [key: string]: unknown;
}
/**
 * A specific version release.
 */
interface VersionRelease {
    type: 'version';
    version: string;
}
/**
 * Prompt the user for the release number.
 */
interface PromptRelease {
    type: 'prompt';
    preid: string;
}
/**
 * A bump release, relative to the current version number.
 */
interface BumpRelease {
    type: ReleaseType;
    preid: string;
}
/**
 * One of the possible Release types.
 */
type Release = VersionRelease | PromptRelease | BumpRelease;
/**
 * Normalized and sanitized options
 */
interface NormalizedOptions {
    release: Release;
    commit?: {
        message: string;
        noVerify: boolean;
        all: boolean;
    };
    tag?: {
        name: string;
    };
    push: boolean;
    files: string[];
    cwd: string;
    interface: Interface;
    ignoreScripts: boolean;
    execute?: string;
    customVersion?: VersionBumpOptions['customVersion'];
    currentVersion?: string;
}

interface OperationState {
    release: ReleaseType | undefined;
    currentVersionSource: string;
    currentVersion: string;
    newVersion: string;
    commitMessage: string;
    tagName: string;
    updatedFiles: string[];
    skippedFiles: string[];
}
interface UpdateOperationState extends Partial<OperationState> {
    event?: ProgressEvent;
    script?: NpmScript;
}
/**
 * All of the inputs, outputs, and state of a single `versionBump()` call.
 */
declare class Operation {
    /**
     * The options for this operation.
     */
    options: NormalizedOptions;
    /**
     * The current state of the operation.
     */
    readonly state: Readonly<OperationState>;
    /**
     * The results of the operation.
     */
    get results(): VersionBumpResults;
    /**
     * The callback that's used to report the progress of the operation.
     */
    private readonly _progress?;
    /**
     * Private constructor.  Use the `Operation.start()` static method instead.
     */
    private constructor();
    /**
     * Starts a new `versionBump()` operation.
     */
    static start(input: VersionBumpOptions): Promise<Operation>;
    /**
     * Updates the operation state and results, and reports the updated progress to the user.
     */
    update({ event, script, ...newState }: UpdateOperationState): this;
}

/**
 * Prompts the user for a version number and updates package.json and package-lock.json.
 *
 * @returns - The new version number
 */
declare function versionBump(): Promise<VersionBumpResults>;
/**
 * Bumps the version number in package.json, package-lock.json.
 *
 * @param release
 * The release version or type. Can be one of the following:
 *
 * - The new version number (e.g. "1.23.456")
 * - A release type (e.g. "major", "minor", "patch", "prerelease", etc.)
 * - "prompt" to prompt the user for the version number
 */
declare function versionBump(release: string): Promise<VersionBumpResults>;
/**
 * Bumps the version number in one or more files, prompting the user if necessary.
 * Optionally also commits, tags, and pushes to git.
 */
declare function versionBump(options: VersionBumpOptions): Promise<VersionBumpResults>;
/**
 * Bumps the version number in one or more files, prompting users if necessary.
 */
declare function versionBumpInfo(arg?: VersionBumpOptions | string): Promise<Operation>;

declare const bumpConfigDefaults: VersionBumpOptions;
declare function loadBumpConfig(overrides?: Partial<VersionBumpOptions>, cwd?: string): Promise<VersionBumpOptions>;
declare function defineConfig(config: Partial<VersionBumpOptions>): Partial<VersionBumpOptions>;

export { type InterfaceOptions, NpmScript, ProgressEvent, type ReleaseType, type VersionBumpOptions, type VersionBumpProgress, type VersionBumpResults, bumpConfigDefaults, versionBump as default, defineConfig, loadBumpConfig, versionBump, versionBumpInfo };
