/// <reference path="../Common/Helpers/LanguageList.ts" />

namespace sharp.Serene.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('sharp.Serene');
    Serenity.EntityDialog.defaultLanguageList = LanguageList.getValue;
}