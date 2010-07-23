﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Siegfried Pammer" email="siegfriedpammer@gmail.com"/>
//     <version>$Revision: 6077 $</version>
// </file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ICSharpCode.Core;
using ICSharpCode.NRefactory.Parser.VB;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Dom.NRefactoryResolver;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Editor.CodeCompletion;

namespace ICSharpCode.VBNetBinding
{
	public class VBNetCompletionItemList : NRefactoryCompletionItemList
	{
		public ITextEditor Editor { get; set; }
		
		public ICompletionListWindow Window { get; set; }
		
		public override CompletionItemListKeyResult ProcessInput(char key)
		{
			if (key == '?' && string.IsNullOrWhiteSpace(Editor.Document.GetText(Window.StartOffset, Window.EndOffset - Window.StartOffset)))
				return CompletionItemListKeyResult.NormalKey;
			
			return base.ProcessInput(key);
		}
	}
}
