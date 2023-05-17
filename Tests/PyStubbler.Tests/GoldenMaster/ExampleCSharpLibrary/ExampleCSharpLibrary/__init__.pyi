__all__ = ['NamespaceOne','NamespaceTwo']
from typing import Tuple, Set, Iterable, List


class BaseClass:
    def __init__(self): ...


class DictionaryParameters:
    def __init__(self, param: Dictionary): ...
    def Method(self, param: Dictionary) -> None: ...
    def ReturnDictionary(self) -> Dictionary: ...


class EmptyClass:
    pass


class ListParameters:
    def __init__(self, param: List): ...
    def Method(self, param: List) -> None: ...
    def ReturnList(self) -> List: ...


class MultipleConstructors:
    @overload
    def __init__(self): ...
    @overload
    def __init__(self, str: str): ...
    @overload
    def __init__(self, str: str, i: int): ...


class NonObsoleteClass:
    def __init__(self): ...
    @property
    def NonObsoleteProperty(self) -> str: ...
    @property
    def ObsoleteProperty(self) -> str: ...
    def NonObsoleteMethod(self) -> None: ...
    def NonObsoleteStaticMethod() -> None: ...


class OutParams:
    def __init__(self): ...
    @overload
    def GetSomething(self) -> Tuple[int]: ...
    @overload
    def GetSomething(self) -> Tuple[str]: ...
    def TryGetSomething(self) -> Tuple[bool, Object]: ...


class OverloadingMethods:
    @overload
    def __init__(self): ...
    @overload
    def __init__(self, param: int): ...
    @overload
    def __init__(self, param: Single): ...
    @overload
    def OverloadedMethod(self) -> None: ...
    @overload
    def OverloadedMethod(self, param: int) -> None: ...
    @overload
    def OverloadedMethod(self, param: Single) -> None: ...
    @overload
    def StaticOverloadedMethod() -> None: ...
    @overload
    def StaticOverloadedMethod(param: int) -> None: ...
    @overload
    def StaticOverloadedMethod(param: Single) -> None: ...


class Properties:
    def __init__(self): ...
    @property
    def GetProperty(self) -> int: ...
    @property
    def GetSetProperty(self) -> int: ...
    @property
    def StaticGetProperty() -> int: ...
    @property
    def StaticGetSetProperty() -> int: ...
    @GetSetProperty.setter
    def GetSetProperty(self, value: int) -> None: ...
    @StaticGetSetProperty.setter
    def StaticGetSetProperty(value: int) -> None: ...


class PublicClass:
    def __init__(self): ...


class PublicEnum:
    #None = 0
    One = 1
    Two = 2
    Three = 3


class RefParams:
    def __init__(self): ...
    @overload
    def GetSomething(self, value: int) -> Tuple[int]: ...
    @overload
    def GetSomething(self, value: str) -> Tuple[str]: ...
    def TryGetSomething(self, value: Object) -> Tuple[bool, Object]: ...


class SingleVsFloatParameters:
    def __init__(self, param: Single): ...
    def Method(self, param: Single) -> None: ...
    def ReturnFloat(self) -> Single: ...


class StaticMethods:
    def __init__(self): ...
    def StaticMethod() -> None: ...
    @overload
    def StaticOverloadedMethod() -> None: ...
    @overload
    def StaticOverloadedMethod(param: int) -> None: ...


class SubClass(BaseClass):
    def __init__(self): ...
