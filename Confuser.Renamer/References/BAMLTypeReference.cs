﻿using System;
using Confuser.Core;
using Confuser.Renamer.BAML;
using dnlib.DotNet;

namespace Confuser.Renamer.References {
	internal class BAMLTypeReference : INameReference<TypeDef> {
		readonly TypeInfoRecord rec;
		readonly TypeSig sig;

		public BAMLTypeReference(TypeSig sig, TypeInfoRecord rec) {
			this.sig = sig;
			this.rec = rec;
		}

		public bool UpdateNameReference(ConfuserContext context, INameService service) {
			if (string.Equals(rec.TypeFullName, sig.ReflectionFullName, StringComparison.Ordinal)) return false;
			rec.TypeFullName = sig.ReflectionFullName;
			return true;
		}

		public bool ShouldCancelRename() => false;
	}
}
