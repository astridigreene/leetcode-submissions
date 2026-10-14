class Solution:
    def isValid(self, s: str) -> bool:
        stack = []
        for bracket in s:
            if bracket == '(' or bracket == '{' or bracket == '[':
                stack.append(bracket)
            elif len(stack) == 0:
                return False
            elif bracket == ')':
                if stack.pop() != '(':
                    return False
            elif bracket == '}':
                if stack.pop() != '{':
                    return False
            elif bracket == ']':
                if stack.pop() != '[':
                    return False
        if len(stack) > 0:
            return False
        return True