import {createRequire as __createRequire} from 'module';var require=__createRequire(import.meta.url);
import {
  __objRest,
  __spreadProps,
  __spreadValues,
  __toESM,
  bumpConfigDefaults,
  isReleaseType,
  loadBumpConfig,
  log_symbols_default,
  require_picocolors,
  versionBump
} from "../chunk-OMAU23UL.mjs";

// src/cli/index.ts
import process2 from "process";

// package.json
var version = "9.4.0";

// src/cli/parse-args.ts
var import_picocolors = __toESM(require_picocolors());
import process from "process";
import fs from "fs/promises";
import fsSync from "fs";
import { valid as isValidVersion } from "semver";
import cac from "cac";
import yaml from "js-yaml";
async function parseArgs() {
  var _a;
  try {
    const { args, resultArgs } = loadCliArgs();
    const parsedArgs = {
      help: args.help,
      version: args.version,
      quiet: args.quiet,
      options: await loadBumpConfig({
        preid: args.preid,
        commit: args.commit,
        tag: args.tag,
        push: args.push,
        all: args.all,
        confirm: !args.yes,
        noVerify: !args.verify,
        files: [...args["--"] || [], ...resultArgs],
        ignoreScripts: args.ignoreScripts,
        currentVersion: args.currentVersion,
        execute: args.execute,
        recursive: !!args.recursive
      })
    };
    if (parsedArgs.options.files && parsedArgs.options.files.length > 0) {
      const firstArg = parsedArgs.options.files[0];
      if (firstArg === "prompt" || isReleaseType(firstArg) || isValidVersion(firstArg)) {
        parsedArgs.options.release = firstArg;
        parsedArgs.options.files.shift();
      }
    }
    if (parsedArgs.options.recursive) {
      if ((_a = parsedArgs.options.files) == null ? void 0 : _a.length) {
        console.log(import_picocolors.default.yellow("The --recursive option is ignored when files are specified"));
      } else {
        parsedArgs.options.files = [
          "package.json",
          "package-lock.json",
          "packages/**/package.json",
          "jsr.json",
          "jsr.jsonc"
        ];
        if (fsSync.existsSync("pnpm-workspace.yaml")) {
          const pnpmWorkspace = await fs.readFile("pnpm-workspace.yaml", "utf8");
          const workspaces = yaml.load(pnpmWorkspace);
          const workspacesWithPackageJson = workspaces.packages.map((workspace) => `${workspace}/package.json`);
          const withoutExcludedWorkspaces = workspacesWithPackageJson.filter((workspace) => {
            var _a2;
            return !workspace.startsWith("!") && !((_a2 = parsedArgs.options.files) == null ? void 0 : _a2.includes(workspace));
          });
          parsedArgs.options.files = parsedArgs.options.files.concat(withoutExcludedWorkspaces);
        }
      }
    }
    return parsedArgs;
  } catch (error) {
    return errorHandler(error);
  }
}
function loadCliArgs(argv = process.argv) {
  const cli = cac("bumpp");
  cli.version(version).usage("[...files]").option("--preid <preid>", "ID for prerelease").option("--all", `Include all files (default: ${bumpConfigDefaults.all})`).option("-c, --commit [msg]", "Commit message", { default: true }).option("--no-commit", "Skip commit", { default: false }).option("-t, --tag [tag]", "Tag name", { default: true }).option("--no-tag", "Skip tag", { default: false }).option("-p, --push", `Push to remote (default: ${bumpConfigDefaults.push})`).option("-y, --yes", `Skip confirmation (default: ${!bumpConfigDefaults.confirm})`).option("-r, --recursive", `Bump package.json files recursively (default: ${bumpConfigDefaults.recursive})`).option("--no-verify", "Skip git verification").option("--ignore-scripts", `Ignore scripts (default: ${bumpConfigDefaults.ignoreScripts})`).option("-q, --quiet", "Quiet mode").option("-v, --version <version>", "Target version").option("--current-version <version>", "Current version").option("-x, --execute <command>", "Commands to execute after version bumps").help();
  const result = cli.parse(argv);
  const rawArgs = cli.rawArgs;
  const args = result.options;
  const hasCommitFlag = rawArgs.some((arg) => ["-c", "--commit", "--no-commit"].includes(arg));
  const hasTagFlag = rawArgs.some((arg) => ["-t", "--tag", "--no-tag"].includes(arg));
  const _a = args, { tag, commit } = _a, rest = __objRest(_a, ["tag", "commit"]);
  return {
    args: __spreadProps(__spreadValues({}, rest), {
      commit: hasCommitFlag ? commit : void 0,
      tag: hasTagFlag ? tag : void 0
    }),
    resultArgs: result.args
  };
}
function errorHandler(error) {
  console.error(error.message);
  return process.exit(9 /* InvalidArgument */);
}

// src/cli/index.ts
async function main() {
  try {
    process2.on("uncaughtException", errorHandler2);
    process2.on("unhandledRejection", errorHandler2);
    const { help, version: version2, quiet, options } = await parseArgs();
    if (help) {
      process2.exit(0 /* Success */);
    } else if (version2) {
      console.log(version);
      process2.exit(0 /* Success */);
    } else {
      if (!quiet)
        options.progress = options.progress ? options.progress : progress;
      await versionBump(options);
    }
  } catch (error) {
    errorHandler2(error);
  }
}
function progress({ event, script, updatedFiles, skippedFiles, newVersion }) {
  switch (event) {
    case "file updated" /* FileUpdated */:
      console.log(log_symbols_default.success, `Updated ${updatedFiles.pop()} to ${newVersion}`);
      break;
    case "file skipped" /* FileSkipped */:
      console.log(log_symbols_default.info, `${skippedFiles.pop()} did not need to be updated`);
      break;
    case "git commit" /* GitCommit */:
      console.log(log_symbols_default.success, "Git commit");
      break;
    case "git tag" /* GitTag */:
      console.log(log_symbols_default.success, "Git tag");
      break;
    case "git push" /* GitPush */:
      console.log(log_symbols_default.success, "Git push");
      break;
    case "npm script" /* NpmScript */:
      console.log(log_symbols_default.success, `Npm run ${script}`);
      break;
  }
}
function errorHandler2(error) {
  let message = error.message || String(error);
  if (process2.env.DEBUG || process2.env.NODE_ENV === "development")
    message = error.stack || message;
  console.error(message);
  process2.exit(1 /* FatalError */);
}
export {
  main
};
