export interface ApiResponseModel<TValue> {
	status: number;
	errors?: string;
	value?: TValue;
}
