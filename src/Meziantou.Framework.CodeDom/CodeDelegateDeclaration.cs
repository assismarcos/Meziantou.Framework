﻿namespace Meziantou.Framework.CodeDom
{
    public class CodeDelegateDeclaration : CodeTypeDeclaration, IParametrableType
    {
        private CodeTypeReference _returnType;

        public CodeTypeReference ReturnType
        {
            get => _returnType;
            set => SetParent(ref _returnType, value);
        }

        public CodeObjectCollection<CodeTypeParameter> Parameters { get; }
        public CodeObjectCollection<CodeMethodArgumentDeclaration> Arguments { get; }

        public CodeDelegateDeclaration()
            : this(null)
        {
        }

        public CodeDelegateDeclaration(string name)
        {
            Arguments = new CodeObjectCollection<CodeMethodArgumentDeclaration>(this);
            Parameters = new CodeObjectCollection<CodeTypeParameter>(this);
            Name = name;
        }
    }
}